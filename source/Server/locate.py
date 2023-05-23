import mysql.connector
import math
import numpy as np
from datetime import datetime

import alerts

#-----------------------------------------------------------------------------
 # SOURCE FILE:    locate.py
 #
 # PROGRAM:        locate.py
 #
 # FUNCTIONS:      string getFloor(targ)
 #                 string[] getBeacons3flr(targ, beaconsfloor)
 #                 int{}[] getBeaconPos(beaclist)
 #                 double getConnectivity2(beaclist, beacpos, refrssi)
 #                 double findDiagonal(beacon1,beacon2)
 #                 double calculateN(d, rssi, A)
 #                 int{} getDeviceBeacon(beaclist, target, envN, A)
 #                 void threeBorderCalc(beaconlist, beaconpos, calcD)
 #                 void uploadLocation(target,x,y,floor,now)
 #                 double{}[] beaconPosToMeters(beaconpos,beaconlist,scaling)
 #                 int getScaling(floor)
 #                 void location(target, refrssi)
 #                 void checkAllLocation()
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A
 #
 # DESIGNER:       Kevin Lo
 #
 # PROGRAMMER:     Kevin Lo
 #
 # NOTES:
 # Module to calculate the location of a device given the rssi dBm of 3 beacons with
 # their coordinates and also alert if it broke a rule using alerts.py module
# --------------------------------------------------------------------------

config = {
  'user': 'admin',
  'password': 'password',
  'host': '192.168.1.240',
  'database': 'tracking_data',
  'raise_on_warnings': True
}

#------------------------------------------------------------------------
 # FUNCTION:       getFloor
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      string getFloor(targ)
 #                 string targ: the target device_mac
 #
 # RETURNS:        string
 #
 # NOTES: Get the floor label of whichever floor the device was recently detected at 
# -----------------------------------------------------------------------
def getFloor(targ):
    beaconlist = []
    conn = mysql.connector.connect(**config)
    cursor = conn.cursor()
    query = "SELECT floor, MAX(date) as recentdate FROM `tracking` INNER JOIN beacon_location ON tracking.beacon_mac= beacon_location.beacon_mac WHERE device_mac=\"%s\" GROUP BY floor ORDER BY recentdate DESC LIMIT 1"
    cursor.execute(query %targ)
    floor = None
    for(flr, date) in cursor:
        floor = flr
    cursor.close()
    conn.close()

    return floor
    
#------------------------------------------------------------------------
 # FUNCTION:       getBeacons3flr
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      string[] getBeacons3flr(targ, beaconsfloor)
 #                 string targ: the target device_mac
 #                 string beaconsfloor: the floor to look beacons at
 #
 # RETURNS:        string[]
 #
 # NOTES: Gets the 3 beacon names with an entry received from device
# -----------------------------------------------------------------------
def getBeacons3flr(targ, beaconsfloor):
    beaconlist = []
    conn = mysql.connector.connect(**config)
    cursor = conn.cursor()
    query = "SELECT tracking.beacon_mac,floor,MAX(date) AS recentdate FROM `tracking` INNER JOIN beacon_location ON tracking.beacon_mac= beacon_location.beacon_mac WHERE (device_mac=\"DEVICEMAC\" AND floor=\"FLOORNAMETESTLONG\") GROUP BY beacon_mac ORDER BY recentdate DESC LIMIT 3"
    query = query.replace("DEVICEMAC", targ)
    query = query.replace("FLOORNAMETESTLONG", beaconsfloor)
    #print(query)
    cursor.execute(query) #replace floor with floor
    for(beacon_macq, floor, date) in cursor:
        beaconlist.append(beacon_macq)
    cursor.close()
    conn.close()
    return beaconlist

#------------------------------------------------------------------------
 # FUNCTION:       getBeaconPos
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      int{}[] getBeaconPos(beaclist)
 #                 string[] beaclist: list of beacon names as a bluetooth MAC address
 #
 # RETURNS:        int{}[]
 #
 # NOTES: Gets the 3 beacon's x,y positions and returns as a dictionary based on beacon names in an array
# -----------------------------------------------------------------------
def getBeaconPos(beaclist):
    beaconloc = {}
    conn = mysql.connector.connect(**config)
    cursor = conn.cursor()
    query = """
    SELECT * FROM `beacon_location` WHERE beacon_mac="BEACONA"
    UNION
    SELECT * FROM `beacon_location` WHERE beacon_mac="BEACONB"
    UNION
    SELECT * FROM `beacon_location` WHERE beacon_mac="BEACONC"
    """
    query = query.replace("BEACONA", beaclist[0])
    query = query.replace("BEACONB", beaclist[1])
    query = query.replace("BEACONC", beaclist[2])

    cursor.execute(query)
    for(beacon_mac, floor, x, y) in cursor:
        beaconloc[beacon_mac] = [x,y]
    cursor.close()
    conn.close()
    return beaconloc

#------------------------------------------------------------------------
 # FUNCTION:       getConnectivity2
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      double getConnectivity2(beaclist, beacpos, refrssi)
 #                 string[] beaclist: list of beacon names as a bluetooth MAC address
 #                 string{}[] beacpos: xy coordinates of beacons
 #                 int refrssi: reference rssi 1 meter from (beacon <- device)
 #
 # RETURNS:        double
 #
 # NOTES: Calculates the environmental factor N
# -----------------------------------------------------------------------
def getConnectivity2(beaclist, beacpos, refrssi): 
    #use 3 separate queries
    environmentN = 0.0
    count = 0
    
    query = """SELECT * FROM(
    (SELECT * FROM `beacon_tracking` WHERE beacon_mac1="BEACONA" AND beacon_mac2="BEACONB" ORDER BY date DESC LIMIT 1)
    UNION
    (SELECT * FROM `beacon_tracking` WHERE beacon_mac1="BEACONA" AND beacon_mac2="BEACONC" ORDER BY date DESC LIMIT 1)
    ) results ORDER BY date DESC LIMIT 1"""
    query = query.replace("BEACONA", beaclist[0])
    query = query.replace("BEACONB", beaclist[1])
    query = query.replace("BEACONC", beaclist[2])
    conn = mysql.connector.connect(**config)
    cursor = conn.cursor()
    cursor.execute(query)
    for(beacon_maca, beacon_macb, rssi, date) in cursor:
        #for each result calculate for n environment factor
        d = findDiagonal(beacpos[beacon_maca], beacpos[beacon_macb]) #scaled to pixels -> meters
        n = calculateN(d,rssi,refrssi) #-60 is reference rssi from device to node 1 meter away, replace with device's reference 1 meter away
        environmentN = environmentN + n
        count = count+1
        
        #print("n=",n)
    cursor.close()
    conn.close()
    
    query = """SELECT * FROM(
    (SELECT * FROM `beacon_tracking` WHERE beacon_mac1="BEACONB" AND beacon_mac2="BEACONC" ORDER BY date DESC LIMIT 1)
    UNION
    (SELECT * FROM `beacon_tracking` WHERE beacon_mac1="BEACONB" AND beacon_mac2="BEACONA" ORDER BY date DESC LIMIT 1)
    ) results ORDER BY date DESC LIMIT 1"""
    query = query.replace("BEACONA", beaclist[0])
    query = query.replace("BEACONB", beaclist[1])
    query = query.replace("BEACONC", beaclist[2])
    conn = mysql.connector.connect(**config)
    cursor = conn.cursor()
    cursor.execute(query)
    for(beacon_maca, beacon_macb, rssi, date) in cursor:
        #for each result calculate for n environment factor
        d = findDiagonal(beacpos[beacon_maca], beacpos[beacon_macb]) #scaled to pixels -> meters
        n = calculateN(d,rssi,refrssi) #-60 is reference rssi from device to node 1 meter away, replace with device's reference 1 meter away
        environmentN = environmentN + n
        count = count+1
        #print("n=",n)
    cursor.close()
    conn.close()
    
    query = """SELECT * FROM(
    (SELECT * FROM `beacon_tracking` WHERE beacon_mac1="BEACONC" AND beacon_mac2="BEACONA" ORDER BY date DESC LIMIT 1)
    UNION
    (SELECT * FROM `beacon_tracking` WHERE beacon_mac1="BEACONC" AND beacon_mac2="BEACONB" ORDER BY date DESC LIMIT 1)
    ) results ORDER BY date DESC LIMIT 1"""
    query = query.replace("BEACONA", beaclist[0])
    query = query.replace("BEACONB", beaclist[1])
    query = query.replace("BEACONC", beaclist[2])
    conn = mysql.connector.connect(**config)
    cursor = conn.cursor()
    cursor.execute(query)
    for(beacon_maca, beacon_macb, rssi, date) in cursor:
        #for each result calculate for n environment factor
        d = findDiagonal(beacpos[beacon_maca], beacpos[beacon_macb]) #scaled to pixels -> meters
        n = calculateN(d,rssi,refrssi) #-60 is reference rssi from device to node 1 meter away, replace with device's reference 1 meter away
        environmentN = environmentN + n
        count = count+1
        #print("n=",n)
    cursor.close()
    conn.close()
    
    environmentN = environmentN/count
    return environmentN

#------------------------------------------------------------------------
 # FUNCTION:       findDiagonal
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      double findDiagonal(beacon1,beacon2)
 #                 double[] beacon1: xy positions of first beacon
 #                 double[] beacon2: xy positions of second beacon
 #
 # RETURNS:        double
 #
 # NOTES: Calculates diagonal using pythagorous to calculate distance between two beacons
 # -----------------------------------------------------------------------
def findDiagonal(beacon1,beacon2):
    calcx = (beacon1[0]-beacon2[0])**2
    calcy = (beacon1[1]-beacon2[1])**2
    calcc = math.sqrt(calcx+calcy)
    return calcc

#------------------------------------------------------------------------
 # FUNCTION:       calculateN
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      double calculateN(d, rssi, A)
 #                 double d: the distance calculated between beacons
 #                 int rssi: the instant RSSI 
 #                 int A: the measured RSSI 1 meter from the beacon
 #
 # RETURNS:        double
 #
 # NOTES: Helper function for calculating environmental factor
# -----------------------------------------------------------------------
def calculateN(d, rssi, A):
    numerator = A - rssi
    denominator = 10 * math.log10(d)
    result = numerator/denominator
    return result

#------------------------------------------------------------------------
 # FUNCTION:       getDeviceBeacon
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      double{}[] getDeviceBeacon(beaclist, target, envN, A)
 #                 string[] beaclist: list of beacon names
 #                 string target: device name to calculate location for
 #                 double envN: the environmental factor
 #                 int A: the measured RSSI 1 meter from beacon
 #
 # RETURNS:        double
 #
 # NOTES: Helper function for calculating environmental factor
# -----------------------------------------------------------------------
def getDeviceBeacon(beaclist, target, envN, A):
    query = """
    (SELECT * FROM `tracking` WHERE beacon_mac="BEACONA" AND device_mac="TARGETA" ORDER BY date DESC LIMIT 1)
    UNION
    (SELECT * FROM `tracking` WHERE beacon_mac="BEACONB" AND device_mac="TARGETA" ORDER BY date DESC LIMIT 1)
    UNION
    (SELECT * FROM `tracking` WHERE beacon_mac="BEACONC" AND device_mac="TARGETA" ORDER BY date DESC LIMIT 1)
    """
    query = query.replace("BEACONA", beaclist[0])
    query = query.replace("BEACONB", beaclist[1])
    query = query.replace("BEACONC", beaclist[2])
    query = query.replace("TARGETA", target)

    conn = mysql.connector.connect(**config)
    cursor = conn.cursor()
    cursor.execute(query)

    calcd = {}
    for(beacon_mac, device_mac, rssi, date) in cursor:
        
        #a is measured
        #rssi is instant
        #measured rssi - instant rssi
        expo = (A-rssi)/(10*envN)
        
        #Distance = 10^((Measured Power - Instant RSSI)/10*N).
        #A is measured power, rssi is instant rssi
        #expo = (A-rssi)/(10*envN)
        
        resultd = 10**expo
        calcd[beacon_mac] = resultd
    cursor.close()
    conn.close()
    return calcd

#------------------------------------------------------------------------
 # FUNCTION:       threeBorderCalc
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      double[] threeBorderCalc(beaconlist, beaconpos, calcD)
 #                 string[] beaconlist: the list of beacon names
 #                 double{}[] beaconpos: the xy coordinates of each beacon
 #                 double{}[] calcD: the calculated distance from beacon to device
 #
 # RETURNS:        double[]
 #
 # NOTES: using formula from https://ieeexplore.ieee.org/stamp/stamp.jsp?tp=&arnumber=9165464
 # to calculate the X,Y position of device for threebordercalc and returns the result
# -----------------------------------------------------------------------
def threeBorderCalc(beaconlist, beaconpos, calcD):
    beac1 = beaconlist[0]
    beac2 = beaconlist[1]
    beac3 = beaconlist[2]
    
    a1 = 2.0*(beaconpos[beac2][0] - 1.0*beaconpos[beac1][0])
    a2 = 2.0*(beaconpos[beac3][0] - 1.0*beaconpos[beac1][0])
    a3 = 2.0*(beaconpos[beac3][0] - 1.0*beaconpos[beac2][0])
    b1 = 2.0*(beaconpos[beac2][1] - 1.0*beaconpos[beac1][1])
    b2 = 2.0*(beaconpos[beac3][1] - 1.0*beaconpos[beac1][1])
    b3 = 2.0*(beaconpos[beac3][1] - 1.0*beaconpos[beac2][1])
    
    c1 = calcD[beac1]**2-calcD[beac2]**2+beaconpos[beac2][0]**2-beaconpos[beac1][0]**2+beaconpos[beac2][1]**2-beaconpos[beac1][1]**2
    c2 = calcD[beac1]**2-calcD[beac3]**2+beaconpos[beac3][0]**2-beaconpos[beac1][0]**2+beaconpos[beac3][1]**2-beaconpos[beac1][1]**2
    c3 = calcD[beac2]**2-calcD[beac3]**2+beaconpos[beac3][0]**2-beaconpos[beac2][0]**2+beaconpos[beac3][1]**2-beaconpos[beac2][1]**2
    
    #make the numbers for the inverse matrix 2x2
    arr1    = a1**2 + a2**2 + a3**2
    arr23   = a1*b1 + a2*b2 + a3*b3
    #arr3   = a1*b1 + a2*b2 + a3*b3
    arr4    = b1**2 + b2**2 + b3**2
    
    #make the numbers for the 1x2 matrix
    arrx = a1*c1 + a2*c2 + a3*c3
    arry = b1*c1 + b2*c2 + b3*c3
    
    #make matrix to invert
    matrix1 = np.matrix([[arr1,arr23],[arr23,arr4]])
    #invert the matrix
    invmatrix = np.linalg.inv(matrix1)
    #make the other matrix for xy
    matrix2 = np.matrix([[arrx],[arry]])
    #multiply both the inverted and xy matrices for result
    result = np.matmul(invmatrix,matrix2)

    #result is the X Y position of the device
    return result

#------------------------------------------------------------------------
 # FUNCTION:       uploadLocation
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      void uploadLocation(target,x,y,floor,now)
 #                 string target: device's bluetooth mac
 #                 int x: calculated x position of the device
 #                 int y: calculated y position of the device
 #                 string floor: floor that the device was tracked most recently
 #                 datetime now: current time
 #
 # RETURNS:        void
 #
 # NOTES: uploads the entry to the database
# -----------------------------------------------------------------------
def uploadLocation(target,x,y,floor,now):
    sql = "INSERT INTO device_tracked_location(DEVICE_MAC,X,Y,FLOOR, DATE) VALUES ('TARGETNAME', 'XPOSITION', 'YPOSITION', 'FLOORPLACE1#!', 'DATETIME')"
    sql = sql.replace("TARGETNAME", target)
    sql = sql.replace("XPOSITION", str(x))
    sql = sql.replace("YPOSITION", str(y))
    sql = sql.replace("FLOORPLACE1#!", floor)
    sql = sql.replace("DATETIME", str(now))
    print(sql)
    conn = mysql.connector.connect(**config)
    cursor = conn.cursor()
    try:
        # Executing the SQL command
        cursor.execute(sql)
        # Commit your changes in the database
        conn.commit()
    except:
        # Rolling back in case of error
        conn.rollback()
        # Closing the connection
        conn.close()

#------------------------------------------------------------------------
 # FUNCTION:       beaconPosToMeters
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      double{}[] beaconPosToMeters(beaconpos,beaconlist,scaling)
 #                 int{}[] beaconpos: dictionary of beacon postions of array
 #                 string[] beaconlist: list of beacon bluetooth macs
 #                 int scaling: the pixels to meters scaling
 #
 # RETURNS:        double{}[]
 #
 # NOTES: converts beacon xy pixel positions to meters
# -----------------------------------------------------------------------
def beaconPosToMeters(beaconpos,beaconlist,scaling):
    for beacname in beaconlist:
        beaconpos[beacname][0] = beaconpos[beacname][0] / scaling
        beaconpos[beacname][1] = beaconpos[beacname][1] / scaling
    return beaconpos
    
#------------------------------------------------------------------------
 # FUNCTION:       getScaling
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      int getScaling(floor)
 #                 string floor: the floor name to get scaling for
 #
 # RETURNS:        int
 #
 # NOTES: gets the pixel to meters scaling given a map name
 # -----------------------------------------------------------------------
def getScaling(floor):    
    conn = mysql.connector.connect(**config)
    cursor = conn.cursor()
    query = "SELECT mapfloor, scaling FROM map_image WHERE mapfloor='" +floor+ "'"
    cursor.execute(query)
    scaling = 1
    for(mapname, scal) in cursor:
        scaling = scal
    cursor.close()
    conn.close()

    return scaling
    
#------------------------------------------------------------------------
 # FUNCTION:       location
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      void location(target, refrssi)
 #                 string target: device's bluetooth mac address
 #                 int refrssi: device's referece RSSI dBm 1 meter from beacon
 #
 # RETURNS:        void
 #
 # NOTES: function to calculate XY position for a single device and upload to database
 # -----------------------------------------------------------------------
#function to calculate the position of one device
#call the function given the target's bt mac address and reference rssi from 1 meter from a beacon
def location(target, refrssi):
    beaconsfloor = getFloor(target)
    #check if beaconsfloor is None, if none dont check
    if(beaconsfloor == None):
        return
    beaconlist = getBeacons3flr(target,beaconsfloor)
    #check if there are 3 beacons for the floor, if there are less than 3, dont check
    if(len(beaconlist) < 3):
        return 
    #pixels to meters
    scaling = getScaling(beaconsfloor)

    #get the positions of the beacons
    beaconpos = getBeaconPos(beaconlist)
    
    #convert position from pixels to meters
    beaconpos = beaconPosToMeters(beaconpos,beaconlist,scaling)
    
    #get the connectivity N based on the beacons and network environment
    envN = getConnectivity2(beaconlist,beaconpos,refrssi)
    
    #calculate the diagonal for each
    calcD = getDeviceBeacon(beaconlist, target, envN, refrssi) #-60 reference rssi 1 meter from beacon on device
    
    position = threeBorderCalc(beaconlist, beaconpos, calcD)
    #send record position to database
    xpos = int(position[0] * scaling)
    ypos = int(position[1] * scaling)
    #print(position[0], position[1])
    print(xpos,ypos)
    
    #upload results to database
    now = datetime.now()
    uploadLocation(target,xpos,ypos,beaconsfloor,now)
    
    #link the alerts.py here
    alerts.alertcheck(target,beaconsfloor,xpos,ypos,now)

#------------------------------------------------------------------------
 # FUNCTION:       checkAllLocation()
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      void checkAllLocation()
 #
 # RETURNS:        void
 #
 # NOTES: checks the location of all devices
 # -----------------------------------------------------------------------
def checkAllLocation():
    beaconlist = []
    conn = mysql.connector.connect(**config)
    cursor = conn.cursor()
    #get list of devices mac and their reference rssi from 1 meter of a beacon
    query = "SELECT * FROM `devices`"
    cursor.execute(query)
    for(device_mac, referencerssi) in cursor:
        #check the location for each device mac with reference rssi
        print("checking " + device_mac)
        location(device_mac, referencerssi)
    cursor.close()
    conn.close()

