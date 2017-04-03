from PIL import ImageGrab
import numpy as np
import cv2
import win32gui
import win32con


def getSize():
    '''
    Return a list of tuples (handler, (width, height)) for each real window.
    '''
	
    def callback(hWnd, windows):
        if win32gui.GetWindowText(hWnd) == "FCEUX 2.1.4a: Pac-Man (USA) (Namco)":
            rect = win32gui.GetWindowRect(hWnd)
            windows.append(rect[0])
            windows.append(rect[1])
            windows.append(rect[2])
            windows.append(rect[3])
    windows = []
    win32gui.EnumWindows(callback, windows)
    return windows
	
while(True):
    #red = getSize()
    #print(red[0], red[1], red[2], red[3])
    img = ImageGrab.grab(bbox=(0,77,384,412)) #bbox specifies specific region (bbox= x,y,width,height)
    img_rgb = np.array(img)
    
    
    img_bgr = cv2.cvtColor(img_rgb, cv2.COLOR_RGB2BGR)
    img_gray = cv2.cvtColor(img_bgr, cv2.COLOR_RGB2GRAY)
    
    ghostThreshold = 0.8
    goodGhostThreshold = 0.82
    
    methods = ['cv2.TM_CCOEFF_NORMED']
    for meth in methods:
        method = eval(meth)
    
        dot = cv2.imread('C:\\Users\\Garth\\Desktop\\script\\dot.png', 0)
        dotw, doth = dot.shape[::-1]
        res = cv2.matchTemplate(img_gray, dot, method)
        
        threshold = 0.8
        loc = np.where(res >= threshold)
        
        for pt in zip(*loc[::-1]):
            cv2.rectangle(img_bgr, pt, (pt[0]+dotw, pt[1]+doth), (0,255,255), 0)
        
        
        
        goodGhost = cv2.imread('C:\\Users\\Garth\\Desktop\\script\\goodGhost.png', 0)
        goodGhostw, goodGhosth = goodGhost.shape[::-1]
        res = cv2.matchTemplate(img_gray, goodGhost, method)
        loc = np.where(res >= goodGhostThreshold)
        
        for pt in zip(*loc[::-1]):
            cv2.rectangle(img_bgr, pt, (pt[0]+goodGhostw, pt[1]+goodGhosth), (0,255,0), 2)
        
        
        
        redGhost = cv2.imread('C:\\Users\\Garth\\Desktop\\script\\redGhost.png', 0)
        redGhostw, redGhosth = redGhost.shape[::-1]
        res = cv2.matchTemplate(img_gray, redGhost, method)
        loc = np.where(res >= ghostThreshold)
        
        for pt in zip(*loc[::-1]):
            cv2.rectangle(img_bgr, pt, (pt[0]+redGhostw, pt[1]+redGhosth), (0, 0,255), 2)
        
        
        
        blueGhost = cv2.imread('C:\\Users\\Garth\\Desktop\\script\\blueGhost.png', 0)
        blueGhostw, blueGhosth = blueGhost.shape[::-1]
        res = cv2.matchTemplate(img_gray, blueGhost, method)
        loc = np.where(res >= ghostThreshold)
        
        for pt in zip(*loc[::-1]):
            cv2.rectangle(img_bgr, pt, (pt[0]+blueGhostw, pt[1]+blueGhosth), (0, 0,255), 2)
        
        
        
        pinkGhost = cv2.imread('C:\\Users\\Garth\\Desktop\\script\\pinkGhost.png', 0)
        pinkGhostw, pinkGhosth = pinkGhost.shape[::-1]
        res = cv2.matchTemplate(img_gray, pinkGhost, method)
        loc = np.where(res >= ghostThreshold)
        
        for pt in zip(*loc[::-1]):
            cv2.rectangle(img_bgr, pt, (pt[0]+pinkGhostw, pt[1]+pinkGhosth), (0, 0,255), 2)
        
        
        
        orangeGhost = cv2.imread('C:\\Users\\Garth\\Desktop\\script\\orangeGhost.png', 0)
        orangeGhostw, orangeGhosth = orangeGhost.shape[::-1]
        res = cv2.matchTemplate(img_gray, orangeGhost, method)
        loc = np.where(res >= ghostThreshold)
        
        for pt in zip(*loc[::-1]):
            cv2.rectangle(img_bgr, pt, (pt[0]+orangeGhostw, pt[1]+orangeGhosth), (0, 0,255), 2)
        
        
        
        orangeGhost2 = cv2.imread('C:\\Users\\Garth\\Desktop\\script\\orangeGhost2.png', 0)
        orangeGhost2w, orangeGhost2h = orangeGhost2.shape[::-1]
        res = cv2.matchTemplate(img_gray, orangeGhost2, method)
        loc = np.where(res >= ghostThreshold)
        
        for pt in zip(*loc[::-1]):
            cv2.rectangle(img_bgr, pt, (pt[0]+orangeGhost2w, pt[1]+orangeGhost2h), (0, 0,255), 2)
        
        
     
        
        
        
        cv2.imshow(meth, img_bgr)
    cv2.waitKey(1)

cv2.destroyAllWindows()
