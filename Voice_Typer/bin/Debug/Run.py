import os
import time
import psutil
import random
import argparse
import keyboard
import threading
from playsound import playsound
import speech_recognition as sr
from pynput.keyboard import Controller

keyboard = Controller()  # Create the controller

def type_string_with_delay(string):
    for character in string:  # Loop over each character in the string
        keyboard.type(character)  # Type the character
        time.sleep(0.04)  # Sleep for the amount of seconds generated



GUI_Running = ""

IS_System_Running = ""

Selected_Language = ""

lan_code = ""

def System_Main():
	
	global GUI_Running, IS_System_Running, Selected_Language, lan_code  

	while True:
		GUI_File = open("System_Status.txt")
		GUI_Running = GUI_File.readline()
		GUI_File.close()

		if GUI_Running.strip() == "True":

			System_Running_File = open("Running_Status.txt")
			IS_System_Running = System_Running_File.readline()
			System_Running_File.close()

			if IS_System_Running.strip() == "Running":


				Language_File = open("Language_Status.txt")
				Selected_Language = Language_File.readline()
				Language_File.close()

				if Selected_Language.strip() == "English":
					lan_code = ""

				elif Selected_Language.strip() == "Tamil":
					lan_code = 'ta'

				elif Selected_Language.strip() == "Sinhala":
					lan_code = 'si'
		
		elif GUI_Running.strip() == "False":
			ThisSystem = psutil.Process(os.getpid())
			ThisSystem.terminate()

thread1 = threading.Thread(target = System_Main)
thread1.start()





while True:

	if IS_System_Running.strip() == "Running":

		r = sr.Recognizer()
		with sr.Microphone() as source:
		    print("Listening...")
		    audio = r.listen(source)
		    
		    try:
		        print("Recognizing...")
		        text = r.recognize_google(audio,language='{}'.format(lan_code))
		        type_string_with_delay(text)
		        
		    except:
		    	print("Please try again!")

		    	'''
		        if Selected_Language.strip() == "English":
		        	playsound("English\\try.mp3")
		        
		        elif Selected_Language.strip() == "Tamil":
		        	playsound("Tamil\\try.mp3")

		        elif Selected_Language.strip() == "Sinhala":
		        	playsound("Tamil\\try.mp3")
				'''


'''

while True:

	if IS_System_Paused == False:

		

'''
