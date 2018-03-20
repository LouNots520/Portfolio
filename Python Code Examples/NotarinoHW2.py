# --------------------------------------------------------------------------- #
# Louis Notarino -------------------- 3/23/17 --------------------- CSCI 4534 #
# HW 2 - RSA Attacks -------------------------------------------------------- #
# --------------------------------------------------------------------------- #
import time


e = int(input('Enter the Encryption Key: '))    #Input: Encryption Key (Public)

n = int(input('Enter N: '))                     #Input: N

cipher = int(input('Enter Cipher: '))           #Input: Ciphertext

# ------------ Attack 1 ------------

print('\n--- Attack 1 ---\n')

start = time.perf_counter()

for m in range(0, n):                   #Generating all possible Messages (m)
    check = pow(m, e, n)
    if check == cipher:                 #Checking for C = M^e mod N
        break
    
end = time.perf_counter()
    
attack1 = (end - start) * 1000000       #Duration of Attack 1

print('Message: ', m)                   #Output

print('\nDuration: ', attack1)

# ---------- End Attack 1 ----------

# ------------ Attack 2 ------------

print('\n--- Attack 2 ----\n')

factors = []                            #Factors of a factor of n
pfactors = []                           #Prime factors of n

start = time.perf_counter()

for x in range(1, n + 1):               #Factor n (Keep prime factors)
    if n % x == 0:                      #Factor of n found
        for y in range(1, x + 1):
            if x % y == 0:
                factors.append(y)
        if len(factors) <= 2:           #Prime factor of n found
            pfactors.append(x)
        factors.clear()

for x in range(len(pfactors) - 1, 1, -1):   #Calculating p and q
    if pfactors[x] * pfactors[x - 1] == n:
        p = pfactors[x]
        q = pfactors[x - 1]

euler = (p - 1) * (q - 1)               #Calculating Euler Totient

d = int((euler + 1) / e)                #Calculating d (Private Encryption Key)

m = pow(cipher, d, n)                   #Getting Message (M = C^d mod N)

end = time.perf_counter()

attack2 = (end - start) * 1000000       #Duration of Attack 2

print('p: ', p)                         #Output
print('q: ', q)
print('d: ', d)
print('M: ', m)

print('\nDuration: ', attack2)
    
# ---------- End Attack 2 ----------

print('\n----------------')

if attack1 < attack2:                   #Comparing durations of attacks
    print('\nAttack 1 was faster.')
elif attack2 < attack1:
    print('\nAttack 2 was faster.')
else:
    print('\nNo time difference recorded.')