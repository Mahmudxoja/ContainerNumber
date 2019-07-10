The program is designed to check the numbers of large capacity and medium capacity containers on the last control digit.
The calculation of the control number is made in the following sequence: each letter character of the owner code is assigned digital equivalent: 

A = 10, B = 12, C = 13, D = 14, E = 15, F = 16, G = 17, H = 18, I = 19, J = 20, 
K = 21, D = 23, M = 24, N = 25, O = 26, P = 27, Y = 28, K = 29, S = 30, T = 31, 
U = 32, V = 34, W = 35, X = 36, Y = 37, Z = 38, 

each digital equivalent of the code and each digit of the number is multiplied by a weight factor, which is the power of the number 2 from 0 to 9 (the number of characters in the code of the owner and the container number), i.e. the first character is multiplied by pow (2, 0), the second by pow (2,1), the last, tenth by pow (2,9); 	the multiplication results are added up and divided into a module equal to 11; the remainder obtained by division is a control number. 

Note, the number of a large=capacity container consists of 11 characters, including 4 letters and 7 digits (for example, OOLU1263890).
Room medium container consists of 9 digits (e.g. 318100531) 
