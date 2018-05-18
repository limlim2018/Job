1.Double-click to run TaskProgram.exe

-----------------------------------------------------------------------------------------------------------------------------

2.The following prompts appear after the program runs.
Programming instructions
C w h                  Create a table      w:width  h:height
N x1 y1 v1             Set a number        x1:X coordinate  y1:X coordinate v1:Value
S x1 y1 x2 y2 x3 y3    Sum                 x1,y1:Num1 coordinate x2,y2:Num2 coordinate x3,y3 Sum coordinate
Q                      Quit

-----------------------------------------------------------------------------------------------------------------------------

3.Command format description:
Command type + space + parameter 1+ space + parameter 2.

<1>.C w h
    C:Represents the creation of a table.    
	w:Represents the width, that is, how many columns to create.
	h:Represents the height, indicating how many rows to create.

<2>.N x1 y1 v1
    N: Represents setting a number.
    x1:Represents the X coordinates to be set to the table.
	y1:Represents the y-coordinate to be set to the table.
    v1:Represents the value to be set to the table.

<3>.S x1 y1 x2 y2 x3 y3
    S:    summation        
	x1,y1:The coordinates of the first number.   
	x2,y2:Represents the coordinates of the second number.   
	x3,y3:Represents the coordinates of the results in the table.

<4>.Q   Quit

-----------------------------------------------------------------------------------------------------------------------------

4. Description of program operation:
<1>. The first step of the program must first create the table. If you enter other commands directly, you will be prompted.
<2>. When entering an illegal command format, the command type is prompted incorrectly.
<3>. The system will be prompted to re-enter when an illegal subscript is entered.
<4>. The size of the number can only support 3 bits, which must be less than 999.
<5>. The sum of the two Numbers must be less than 999, otherwise the system will be prompted.
