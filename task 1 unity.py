# task 1 unity #
import cv2
import mediapipe as mp
import math
import socket
from cvzone.HandTrackingModule import HandDetector
#params
width, height =1280, 720
is_shooting= "False"
is_dashing = "dashing"
#camera instance
cap = cv2.VideoCapture(0)
cap.set(3, 1280)
cap.set(4, 720)
#hand detector
detector = HandDetector(maxHands=1, detectionCon=0.8)

#comunication with unity
sock= socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)

sock_1= socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
serverAddressPort_1 = ("127.0.0.1", 5234)

sock_3= socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
serverAddressPort_3 = ("127.0.0.1", 5244)
while True:

    success, img = cap.read()

    hands, img = detector.findHands(img)
    #lmList = detector.findPosition(img, draw=False)
   #landMaek
    Data=[]
    NewData=[]
    NewNewData=[]

   #Landmark values - (x,y,z) * 21
    if hands:
        hand = hands[0]
        lmList = hand['lmList']

        # print(lmList)
        if len(lmList)!=0 :
           # print(lmList[4], lmList[8])
            x1, y1, z1 = lmList[4][0], lmList[4][1], lmList[4][2]
            x2, y2, z2 = lmList[8][0], lmList[8][1], lmList[8][2]
            x3, y3, z3 = lmList[20][0], lmList[20][1], lmList[20][2]

            cv2.circle(img ,(x1,y1),15 ,(255,0,255),cv2.FILLED)
            cv2.circle(img, (x2, y2 ), 15, (255, 0, 255), cv2.FILLED)
            cv2.circle(img, (x3, y3), 15, (255, 0, 255), cv2.FILLED)
            cv2.line(img,(x1,y1), (x2, y2 ), (255, 0, 255), 3)
            cv2.line(img, (x1, y1), (x3, y3), (255, 0, 255), 3)

            length = math.hypot(x2-x1,y2-y1)
            Length_2 = math.hypot(x3 - x1, y3 - y1)
           # print(Length_2)
            if Length_2 < 40:
                is_dashing = "dashing"
            else:
                is_dashing = "not_dashing"
            if length < 40 :
                #print(length)
                is_shooting = "true"

            else:
                #print(length)
                is_shooting = "false"
            print("is dashing "+ is_dashing)
            print("is shooting " + is_shooting)
            Data.extend([is_shooting])
            NewNewData.extend([is_dashing])
            sock_1.sendto(str.encode(str(Data)), serverAddressPort_1)
            sock_3.sendto(str.encode(str(NewNewData)), serverAddressPort_3)

        for lm in lmList:
            NewData.extend([lm[0], height-lm[1], lm[2]])
        sock.sendto(str.encode(str(NewData)), serverAddressPort)
    #else:
    cv2.imshow("Image", img)

    cv2.waitKey(1)

