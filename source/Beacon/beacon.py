#used to scan bluetooth and read the data
import bluetooth
import select

#for date time
from datetime import datetime

##for connecting to sql (for server side, not this one
##import mysql.connector

#for socket tcp to send beacon data to server
import socket

#to encode decode data structures
import pickle

#used to use shell commands
import os

#used to make broadcasting thread
import threading

#used to use a cmd command and pipe output of it to be used
import subprocess

import time

#-----------------------------------------------------------------------------
 # SOURCE FILE:    beacon.py
 #
 # PROGRAM:        beacon.py
 #
 # FUNCTIONS:      void getMac()
 #                 void sendData(devicemac, rssi, devtype)
 #                 MyDiscoverer(bluetooth.DeviceDiscoverer)
 #                 void makeAdvertise():
 #                 void scan():
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A
 #
 # DESIGNER:       Kevin Lo
 #
 # PROGRAMMER:     Kevin Lo
 #
 # NOTES: Server program to run for the beacon tracking program
# --------------------------------------------------------------------------

#------------------------------------------------------------------------
 # FUNCTION:       getMac
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      string getMac()
 #
 # RETURNS:        string
 #
 # NOTES: returns the mac address of the bluetooth adapter of this beacon device in the format of
 # AA:BB:CC:DD:EE:FF
# -----------------------------------------------------------------------
def getMac():
    device_id = "hci0"
    result = subprocess.run(['hciconfig', 'hci0'], stdout=subprocess.PIPE)
    cmdout = result.stdout.decode('utf-8')
    bt_mac = cmdout.split("{}:".format(device_id))[1].split("BD Address: ")[1].split(" ")[0].strip()
    return bt_mac

#------------------------------------------------------------------------
 # FUNCTION:       sendData
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      void sendData(devicemac, rssi, devtype):
 #                 string devicemac: the device's bluetooth mac address
 #                 int rssi: the RSSI dBm signal strength recieved
 #                 int devtype: the devicetype, 0 for device, 1 for beacon
 #
 # RETURNS:        string
 #
 # NOTES: pickle.dumps() use to convert to sendable
 # pickle.loads() to recover the datea
 # devtype 0 is device, 1 is beacon
# -----------------------------------------------------------------------
def sendData(devicemac, rssi, devtype):
    #print("sending to server")
    #tcp send the data to the server
    #the server will then add the entry itself
    host = "192.168.1.240" #read ip address from a setup file
    port = 50
    
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock.connect((host,port))
    
    now = datetime.now()
    #make data structure to contain, beaconmac,devicemac, rssi, date
    packetdata = (beaconmac, devicemac, rssi, now, devtype)

    print(packetdata)
    sock.send(pickle.dumps(packetdata))
    
    sock.close()

#------------------------------------------------------------------------
 # Class:          MyDiscoverer
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # NOTES: custom pybluez class that changes how pybluez scan operates
# -----------------------------------------------------------------------
class MyDiscoverer(bluetooth.DeviceDiscoverer):
    
    def pre_inquiry(self):
        self.done = False
    
    #is called by process_event when a device is discovered
    def device_discovered(self, addresstarg, device_class, rssi, name):
        #send this to the server with beacon and device mac address with rssi with current time
        
        #check the services of the speciic bluetooth device
        #if it matches a beacon's signature, send the data as a beacon scan
        services = bluetooth.find_service(address=addresstarg, uuid="11111111-2222-3333-4444-555555555555")
        isbeacon = False
        for svc in services:
            #print("    service id: ", svc["service-id"])
            if svc["service-id"] == "11111111-2222-3333-4444-555555555555":
                isbeacon = True
        
        if(isbeacon):
            #send as beacon rssi data
            sendData(addresstarg, rssi, 1)
        else:
            #send as device rssi data
            sendData(addresstarg, rssi, 0)
        
    def inquiry_complete(self):
        self.done = True


#------------------------------------------------------------------------
 # FUNCTION:       makeAdvertise
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      void makeAdvertise()
 #
 # RETURNS:        void
 #
 # NOTES: makes the beacon advertise as a beacon by using unique uuid 11111111-2222-3333-4444-555555555555
# -----------------------------------------------------------------------
def makeAdvertise():
    server_sock = bluetooth.BluetoothSocket(bluetooth.RFCOMM)
    server_sock.bind(("", bluetooth.PORT_ANY))
    server_sock.listen(5)
    
    #port = server_sock.getsockname()[1]
    
    uuid = "11111111-2222-3333-4444-555555555555"
    bluetooth.advertise_service(
        server_sock, "SampleServer",
        service_id = uuid,
        service_classes = [uuid, bluetooth.SERIAL_PORT_CLASS],
        profiles = [bluetooth.SERIAL_PORT_PROFILE], 
        # protocols = [OBEX_UUID] 
    )
    print("Waiting for connection on RFCOMM channel")
    client_sock, client_info = server_sock.accept()

#------------------------------------------------------------------------
 # FUNCTION:       scan
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      void scan()
 #
 # RETURNS:        void
 #
 # NOTES: performs scanning actions
# -----------------------------------------------------------------------
def scan():
    #repeat this to constantly scan
    d = MyDiscoverer()
    devicelist = d.find_devices(duration = 10, lookup_names = False, flush_cache=False)
    readfiles = [ d, ]
    
    while True:
        rfds = select.select( readfiles, [], [] )[0]
        if d in rfds:
            try:
                d.process_event()
            except:
                pass
        if d.done:
            break

#========================================
#setup by getting the beacon's mac on startup
beaconmac = getMac()
print("The beacon address of this beacon is " + beaconmac)

#start hciconfig hciX piscan
os.system("hciconfig hciX piscan")

#make advertising thread
print("starting broadcasting thread")
thAdvert = threading.Thread(target=makeAdvertise)
thAdvert.daemon = True
thAdvert.start()

#make loop scanning processes
while True:
    
    thScan = threading.Thread(target=scan)
    thScan.daemon = True
    thScan.start()
    
    time.sleep(5)

    
th.join()
