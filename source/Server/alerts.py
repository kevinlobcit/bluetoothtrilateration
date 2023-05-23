import mysql.connector
from datetime import datetime

#-----------------------------------------------------------------------------
 # SOURCE FILE:    alerts.py
 #
 # PROGRAM:        alerts.py
 #
 # FUNCTIONS:      bool checkrule(x,y,x_start,y_start,x_end,y_end)
 #                 int{}[] string[] getrules(device_mac, floor)
 #                 void sendalertdatabase(rulename,device_mac,floor,y,x,date)
 #                 void alertcheck(device_mac, floor, x, y, date)
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
 # Module to check if the x,y,device_mac,floor combinations violates any alert rules made
# --------------------------------------------------------------------------


config = {
  'user': 'admin',
  'password': 'password',
  'host': '192.168.1.240',
  'database': 'tracking_data',
  'raise_on_warnings': True
}


#recieve the device_mac, floor,date  x,ycoordinates from locate.py
#sql for the rules relevant to the devicemac + floor
#SELECT * FROM alert_rules WHERE device_mac = "devicename" AND mapfloor = "floor"

#for each row, check if the x,y coordinates are inside the rectangle created by xy start/endswith

#xstart < x < xend AND ystart < y < yend
#if (xstart <= x) && (x <= xend):
    #widthinside = true
#if (ystart <= y) && (y <= yend):
    #heightinside = true
    
#if(widthinside && heightinside):
    #trigger alert

#------------------------------------------------------------------------
 # FUNCTION:       checkrule
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      bool checkrule(x,y,x_start,y_start,x_end,y_end)
 #                 int x: Reported x coordinate of device
 #                 int y: Reported y coordinate of device
 #                 int x_start: Starting x coordinate of rule
 #                 int y_start: Starting y coordinate of rule
 #                 int x_end: Ending x coordinate of rule
 #                 int y_end: Ending y coordinate of rule
 #
 # RETURNS:        bool
 #
 # NOTES: Checks if X and Y are inside the bounds of the rules, return true if it is in the rectangle
 # produced by xy start and xy end else return false
 # -----------------------------------------------------------------------
def checkrule(x,y,x_start,y_start,x_end,y_end):
    widthinside = False
    heightinside = False
    if (x_start <= x) and (x <= x_end):
        widthinside = True
    if (y_start <= y) and (y <= y_end):
        heightinside = True  
    return (widthinside and heightinside)    

#------------------------------------------------------------------------
 # FUNCTION:       getrules
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      bool getrules(device_mac,floor)
 #                 string device_mac: device_mac name
 #                 string floor: floor name 
 #
 # RETURNS:        int{}[] rulenames[]
 #
 # NOTES: returns the alertrules dictionary array of integers representing the xy start end
 # for each rule along with the corresponding array of rulenames to access the dictionary
 # -----------------------------------------------------------------------
def getrules(device_mac,floor):
    alertrules = {} #contains the coordinates linked to the rule dictionary
    rulenames = [] #contains the name of the rules relevant
    conn = mysql.connector.connect(**config)
    cursor = conn.cursor()
    query = "SELECT * FROM `alert_rules` WHERE device_mac=\"%s\" AND mapfloor='MAPFLOORNAME1234'"
    query = query.replace("MAPFLOORNAME1234", floor) 
    cursor.execute(query %device_mac)
    for(rule_name, dev_mac, flr, x_start, y_start, x_end, y_end) in cursor:
        rulenames.append(rule_name) #save the rule name so can use in dictionary search later
        alertrules[rule_name] = [x_start,y_start,x_end,y_end]
    cursor.close()
    conn.close()
    return rulenames, alertrules

#------------------------------------------------------------------------
 # FUNCTION:       sendalertdatabase
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      sendalertdatabase(rulename,device_mac,floor,y,x,date)
 #                 string rulename: name of the rule 
 #                 string device_mac: device_mac name
 #                 string floor: floor name
 #                 int x: x position of the device
 #                 int y: y position of the device
 #                 datetime date: the current time of the device's position 
 #
 # RETURNS:        void
 #
 # NOTES: inserts the new detection into the database
 # -----------------------------------------------------------------------
def sendalertdatabase(rulename,device_mac,floor,y,x,date):
    sql = "INSERT INTO alert_detections(RULE_NAME,DEVICE_MAC,MAPFLOOR,X,Y,DATE) VALUES ('RULENAMEASDF', 'DEVMACASDF', 'FLOORPLACE1#!', 'XPOS', 'YPOS', 'DATETIME')"
    sql = sql.replace("RULENAMEASDF", rulename)
    sql = sql.replace("DEVMACASDF", device_mac)
    sql = sql.replace("XPOS", str(x))
    sql = sql.replace("YPOS", str(y))
    sql = sql.replace("FLOORPLACE1#!", floor)
    sql = sql.replace("DATETIME", str(date))
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
 # FUNCTION:       alertcheck
 #
 # DATE:           April 27, 2023
 #
 # REVISIONS:      N/A (Date and explanation of revisions if applicable)
 #
 # INTERFACE:      alertcheck(device_mac, floor, x, y, date)
 #                 string device_mac: device_mac name
 #                 string floor: floor name
 #                 int x: x position of the device
 #                 int y: y position of the device
 #                 datetime date: the current time of the device's position 
 #
 # RETURNS:        void
 #
 # NOTES: gets the rules, and checks the rule, and uploads the infringing result to the database if rulecheck is true
 # -----------------------------------------------------------------------
def alertcheck(device_mac, floor, x, y, date):
    rulenames, alertrules = getrules(device_mac,floor)
    
    for rulename in rulenames:
        x_start = alertrules[rulename][0]
        y_start = alertrules[rulename][1]
        x_end = alertrules[rulename][2]
        y_end = alertrules[rulename][3]
        
        rulecheck = checkrule(x,y,x_start,y_start,x_end,y_end)
        #print(rulecheck)
        if(rulecheck): #if is true, send to database
            sendalertdatabase(rulename,device_mac,floor,y,x,date)
            
        
    
