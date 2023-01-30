.data
 vecs1 DD 3.063218, -1.393325, -0.475802, 0.0
 vecs2 DD -0.969243, 1.875966, 0.041555, 0.0
 vecs3 DD 0.067871,-0.228834, 1.069251, 0.0
 vecs4 DD 0.0,0.0,0.0,0.0

 vecs5 DD 3.063218, -1.393325, -0.475802, 0.0
 vecs6 DD -0.969243, 1.875966, 0.041555, 0.0
 vecs7 DD 0.067871,-0.228834, 1.069251, 0.0
 vecs8 DD 0.0,0.0,0.0,0.0
.code
SimulatorAsm proc
movups xmm0, [rcx]
movups xmm1, [vecs1]
movups xmm2, [vecs2]
movups xmm3, [vecs3]
mulps xmm1,  xmm0
mulps xmm2,  xmm0
mulps xmm3,  xmm0
movups xmm4, [vecs4]
haddps xmm1, xmm4
haddps xmm1, xmm4
movd eax, xmm1
mov [rcx], eax
haddps xmm2, xmm4
haddps xmm2, xmm4
movd eax, xmm2
mov [rcx+4], eax
haddps xmm3, xmm4
haddps xmm3, xmm4
movd eax, xmm3
mov [rcx+8], eax
; nastêpne 3 wartosci
movups xmm0, [rdx]
movups xmm1, [vecs5]
movups xmm2, [vecs6]
movups xmm3, [vecs7]
mulps xmm1,  xmm0
mulps xmm2,  xmm0
mulps xmm3,  xmm0
movups xmm4, [vecs8]
haddps xmm1, xmm4
haddps xmm1, xmm4
movd eax, xmm1
mov [rcx+12], eax
haddps xmm2, xmm4
haddps xmm2, xmm4
movd eax, xmm2
mov [rcx+16], eax
haddps xmm3, xmm4
haddps xmm3, xmm4
movd eax, xmm3
mov [rcx+20], eax
; return
ret
SimulatorAsm endp
end