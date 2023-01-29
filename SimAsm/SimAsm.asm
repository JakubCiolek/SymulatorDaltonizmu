
;.code
;MyProc1 proc
;add RCX, RDX
;mov RAX, RCX
;ret
;MyProc1 endp
;end

.data
 vecs1 DD 3.063218, 0.969243, 0.067871
 vecs2 DD 1.393325, 1.875966, 0.228834
 vecs3 DD 0.475802,0.041555, 1.069251

 vecd1 DD 3.063218, 0.969243, 0.067871
 vecd2 DD 1.393325, 1.875966, 0.228834
 vecd3 DD 0.475802,0.041555, 1.069251

r1 DD 3.063218
r2 DD 0.969243
r3 DD 0.067871

g1 DD 3.063218
g2 DD -0.969243
g3 DD 0.067871

b1 DD 0.067871
b2 DD 0.228834
b3 DD 1.069251

.code
SimulatorAsm proc
    ; Load x, y, z into xmm0
    ; movss xmm0, [esp + 16]
    ; movss xmm1, [esp + 32]
    ; movss xmm2, [esp + 48]

    ; Convert to RGB
    ; r = 3.063218f * x - 1.393325f * y - 0.475802f * z;
    ; g = -0.969243f * x + 1.875966f * y + 0.041555f * z;
    ; b = 0.067871f * x - 0.228834f * y + 1.069251f * z;

    ; mno¿enie wektora 1 przez X
    ;movups xmm3, vecs1 ; przeniesienie tablicy do xmm3
    ;mulps xmm3, xmm0 ;  mno¿enie przez xmm0 w którym znajduje siê X
    ;movups vecs1, xmm3 ; zapisanie wyniku do tablicy

    ;r = 3.063218f * x
    movss xmm3, r1
    mulss xmm3, xmm0
    
    ; r -= 1.393325f * y
    movss xmm4, r2
    mulss xmm4, xmm1
    subss xmm3, xmm4
    
    ; r -= 0.475802f * z
    movss xmm4, r3
    mulss xmm4, xmm2
    subss xmm3, xmm4
    
    ; g = -0.969243f * x
    movss xmm4, g1
    mulss xmm4, xmm0
    
    ; g += 1.875966f * y
    movss xmm5, g2
    mulss xmm5, xmm1
    addss xmm4, xmm5
    
    ; g += 0.041555f * z
    movss xmm5, g3
    mulss xmm5, xmm2
    addss xmm4, xmm5
    
    ; b = 0.067871f * x
    movss xmm5, b1
    mulss xmm5, xmm0
    
    ; b -= 0.228834f * y
    movss xmm6, b2
    mulss xmm6, xmm1
    addss xmm5, xmm6
    
    ; b += 1.069251f * z
    movss xmm6, b3
    mulss xmm6, xmm2
    addss xmm5, xmm6
    
    ;return r, g, b
    movss xmm0, xmm3
    movss xmm1, xmm4
    movss xmm2, xmm5 
    
    ; return
    ret
    SimulatorAsm endp
    end