import socket

#add threading library
from _thread import *
import threading

import time

#for connecting to sql (for server side, not this one
import mysql.connector

#to encode decode data structures
import pickle

import locate

#-----------------------------------------------------------------------------
 # SOURCE FILE:    server.py
 #
 # PROGRAM:        server.py
 #
 # FUNCTIONS:      void addToDatabase(data):
 #                 void threadResponse(conn):
 #                 void checklocationthread():
 #                 void Main():
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

config = {
  'user': 'admin',
  'password': 'password',
  'host': '192.168.1.240',
  'database': 'tracking_data',
  'raise_on_warnings': True
}

#------------------------------------------------------------------------
 # FUNCTION:       addToDatabase
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      void addToDatabase(data)
 #                 packet data: the data from beacon bluetooth scans
 #
 # RETURNS:        void
 #
 # NOTES: adds the bluetooth scan results from beacons to the database
# -----------------------------------------------------------------------
def addToDatabase(data):
    #create mysql link to connect to localhost to tracking_data database
    conn = mysql.connector.connect(**config)
    #create cursor object usiyng the cursor() method
    cursor = conn.cursor()
    
    #check data[4] which is 0 for device rssi packet, 1 for beacon rssi packet
    sql = ""
    #prepare sql query to insert record to database
    #basesql = "INSERT INTO tracking(BEACON_MAC, DEVICE_MAC, RSSI, DATE) VALUES ('38:E7:C0:F9:9E:D9', 'DC:1B:A1:4D:85:6D', '-50', '2023-02-23 00:37:26.264295')"
    if data[4] == 0:
        basesql = "INSERT INTO tracking(BEACON_MAC, DEVICE_MAC, RSSI, DATE) VALUES"
        insertsql = "('" + data[0] + "','" + data[1] + "','" + str(data[2]) + "','" + str(data[3]) + "')"
        sql = basesql + insertsql
    elif data[4] == 1:
        basesql = "INSERT INTO beacon_tracking(BEACON_MAC1, BEACON_MAC2, RSSI, DATE) VALUES"
        insertsql = "('" + data[0] + "','" + data[1] + "','" + str(data[2]) + "','" + str(data[3]) + "')"
        sql = basesql + insertsql
    
    try:
        # Executing the SQL command
        cursor.execute(sql)
        # Commit your changes in the database
        conn.commit()
        #conn.close()
    except:
        # Rolling back in case of error
        conn.rollback()
        # Closing the connection
        conn.close()

#------------------------------------------------------------------------
 # FUNCTION:       threadResponse
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      void threadResponse(conn)
 #                 connection conn: the connection from beacon
 #
 # RETURNS:        void
 #
 # NOTES: reads the data and unpacks it and calls the function to add the bluetooth scan results from beacons to the database
# -----------------------------------------------------------------------
def threadResponse(conn):
    print("thread started")
    while True:
        #data recieved from beacon
        data = conn.recv(1024)
        
        #exit when theres no more data to read
        if not data:
            #print("no data")
            #print("-----")
            break
        
        #process the data by append to database
        packetdata = pickle.loads(data)
        print(packetdata)
        #verify the data
        #--
        #add to database
        addToDatabase(packetdata)
        
        #print(data)
    conn.close()

#------------------------------------------------------------------------
 # FUNCTION:       checklocationthread
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      void checklocationthread()
 #
 # RETURNS:        void
 #
 # NOTES: calls the function to check the location of all devices and check if it breaks any alert rules using
 # locate.py and alert.py modules
# -----------------------------------------------------------------------
def checklocationthread():
    while True:
        locate.checkAllLocation()
        time.sleep(2) #sleep for 5 seconds before repeat
    
#------------------------------------------------------------------------
 # FUNCTION:       Main
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      void Main
 #
 # RETURNS:        void
 #
 # NOTES: the main function to start the server
# -----------------------------------------------------------------------
def Main():
    print("Starting check location thread")
    th = threading.Thread(target=checklocationthread)
    th.daemon = True
    th.start()

    host = ""
    port = 50
    print("Starting bluetooth server")
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock.bind((host,port))
    sock.listen(200)
    
    while True:
        #accept client connections
        #print("listening for connections")
        conn, addr = sock.accept()
        #print("Connected to: ", addr[0], ":", addr[1])
        
        #start thread to deal with client
        start_new_thread(threadResponse, (conn,))
    
    print("stopping server")
    sock.close()
    
if __name__ == "__main__":
    Main()