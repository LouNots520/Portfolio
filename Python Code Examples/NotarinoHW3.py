# --------------------------------------------------------------------------- #
# Louis Notarino -------------------- 4/20/17 --------------------- CSCI 4534 #
# HW 3 - DSA ---------------------------------------------------------------- #
# --------------------------------------------------------------------------- #

p = int(input('Enter Global Public Key Value p: '))     #Input: Global Value p

q = int(input('Enter Global Public Key Value q: '))     #Input: Global Value q

h = int(input('Enter Chosen Value of h: '))             #Input: Value of h

x = int(input('Enter Private Key Value x: '))           #Input: Private Key x

k = int(input('Enter Random Secret Number k: '))        #Input: Random Number k

hm1 = int(input('Enter Real Hash Value of m H(M1): '))  #Input: Real Hash Value

hm2 = int(input('Enter Fake Hash Value of m H(M2): '))  #Input: Fake Hash Value


g = pow(h, int((p - 1) / q), p)             #Calculating g

y = pow(g, x , p)                           #Calculating Public Key y

print('\n--------------------\n')           #Output of g and y
print('g: ', g)
print('y: ', y)

# ----------- Signature With H(M1) -----------

r = pow(g, k, p) % q                        #Calculating r
       
for kin in range(0, q - 1):                 #Calculating k Inverse
    check = (kin * k) % q
    if check == 1:
        break
       
s = (kin * (hm1 + x * r)) % q               #Calculating s
    
print('\nSignature With H(M1) - (r, s): (', r, ', ', s, ')')

# ------ Signiture Verification (H(M1)) ------

for sin in range(0, q - 1):                 #Calculating s Inverse
    check = (sin * s) % q
    if check == 1:
        break

w = sin % q                                 #Calculating w

u1 = (hm1 * w) % q                          #Calculating u1

u2 = (r * w) % q                            #Calculating u2

v = ((pow(g, u1) * pow(y, u2)) % p ) % q    #Calculating v
    
print('\n w: ', w)                          #Output
print('u1: ', u1)
print('u2: ', u2)
print(' v: ', v)
    
if v == r:                                  #Checking if Signature is Verified
    print('\nSigniture Verified')
else:
    print('\nSigniture Not Verified')
    
# ------ Signiture Verification (H(M2)) ------

print('\n----- Using H(M2) Value -----')
                                
for sin in range(0, q - 1):                 #Calculating s Inverse
    check = (sin * s) % q
    if check == 1:
        break

w = sin % q                                 #Calculating w

u1 = (hm2 * w) % q                          #Calculating u1

u2 = (r * w) % q                            #Calculating u2

v = ((pow(g, u1) * pow(y, u2)) % p ) % q    #Calculating v
    
print('\n w: ', w)                          #Output
print('u1: ', u1)
print('u2: ', u2)
print(' v: ', v)
    
if v == r:                                  #Checking if Signature is Verified
    print('\nSigniture Verified')
else:
    print('\nSigniture Not Verified')