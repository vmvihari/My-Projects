'''
Name          :   Monish Vihari Vappangi
Date          :   March 7th 2016
Class         :   CS524-02
Description   :   The program is an implementation of Vigenère cipher which is used to encode or decode any plain test with a code word.
                  The program provides three options to the users:
                  1. Encode
                  2. Decode
                  3. Exit
                  On choosing option one or two, the console asks for the name of the file to be encrypted/decrypted, the code word with
                  which the file needs to be encrypted/decrypted. The output is in a file generated in the same location as the input
                  file with an _e for encryption and _d for decryption appended to the input filename. After the file is generated the
                  program provides the options once again to the user. It doesnot exit until the user chooses to exit.
'''

# utilities
import os.path

# Function to read a file name and checkfor its existence
def ReadFile ():
    try:
        while (True):
            FileName = input ("\nPlease enter name or path of the file to be encrypted/decrypted: ")
            if (os.path.isfile(FileName)): break
            else: print ("\nInvalid input: File doesnot exist")

    except: print ("\nInvalid input: File doesnot exist")

    finally: return FileName

    

# Function to read a secret code word for encrypting or decryption
def ReadCode ():
    try:
        while (True):
            CodeWord = input ("\nPlease enter code word for encoding: ")
            if (CodeWord.isalpha()): break
            else: print ("\nInvalid input: Code word should consist of only alphabets")

    except: print ("\nError occured")

    finally: return CodeWord



def Coding(FileName, CodeWord, CodingMode):
    try:
        # Encoding or Decoding algorithm
        Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        fName, fExtn = os.path.splitext (FileName)
        
        if CodingMode == "ENCODE":
            CodeFileName = fName + "_e" + fExtn
        if CodingMode == "DECODE":
            CodeFileName = fName + "_d" + fExtn
            
        inFile = open (FileName, 'r')
        outFile = open (CodeFileName, 'w')
        count = 0;
        while True:
            fChar = inFile.read (1)

            if not fChar: break
            
            if fChar.isalpha():
                num = Alpha.find (fChar.upper())
                
                if CodingMode == "ENCODE":
                    num += Alpha.find (CodeWord[count % len(CodeWord)])
                elif CodingMode == "DECODE":
                    num -= Alpha.find (CodeWord[count % len(CodeWord)])
                num %= len(Alpha)

                if fChar.isupper():
                    outFile.write (Alpha[num])
                elif fChar.islower():
                    outFile.write (Alpha[num].lower())

                count += 1
            else:
                outFile.write (fChar)

    except:
        print ("\nError occured")
        CodeFileName = "Error"

    finally:
        inFile.close()
        outFile.close()
        return CodeFileName
    

    

# Function to encode a file
def EncodeFile (FileName, CodeWord):
    try:
        # Encoding algorithm
        return Coding(FileName, CodeWord, "ENCODE")

    except: print ("\nError occured")

        

# Function to decode a file
def DecodeFile (FileName, CodeWord):
    try:
        # Decoding algorithm
        return Coding(FileName, CodeWord, "DECODE")

    except: print ("\nError occured")

        

try:
    while (True):
        print ("\nPlease choose one option (1 or 2 or 3):\n1. Encode\n2. Decode\n3. Exit")
        choice = int(input())

        if (choice == 1):
            # Encode option
            FileName = ReadFile ()
            CodeWord = ReadCode ()
            CodeFileName = EncodeFile (FileName, CodeWord)
            print ("\nFile has been encrypted successfully: ", CodeFileName)
            
        elif (choice == 2):
            # Decode option
            FileName = ReadFile ()
            CodeWord = ReadCode ()
            CodeFileName = DecodeFile (FileName, CodeWord)
            print ("\nFile has been decrypted successfully: ", CodeFileName)
            
        elif (choice == 3):
            # Stop the program
            print ("\nThank you........")
            break
        
        else:
            # Wrong choice
            print ("\nInvalid choice: Please choose the correct option again")

except: print ("\nError occured")
