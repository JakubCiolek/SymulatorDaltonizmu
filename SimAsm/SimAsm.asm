.code
Simulator proc
    ; Load x, y, z into xmm0
    movss xmm0, [esp + 4]
    movss xmm1, [esp + 8]
    movss xmm2, [esp + 12]

    ; Convert to RGB
    ; r = 3.063218f * x - 1.393325f * y - 0.475802f * z;
    ; g = -0.969243f * x + 1.875966f * y + 0.041555f * z;
    ; b = 0.067871f * x - 0.228834f * y + 1.069251f * z;

    ; r = 3.063218f * x
    movss xmm3, _3_063218
    mulss xmm3, xmm0

    ; r -= 1.393325f * y
    movss xmm4, _1_393325
    mulss xmm4, xmm1
    subss xmm3, xmm4

    ; r -= 0.475802f * z
    movss xmm4, _0_475802
    mulss xmm4, xmm2
    subss xmm3, xmm4

    ; g = -0.969243f * x
    movss xmm4, _m_969243
    mulss xmm4, xmm0

    ; g += 1.875966f * y
    movss xmm5, _1_875966
    mulss xmm5, xmm1
    addss xmm4, xmm5

    ; g += 0.041555f * z
    movss xmm5, _0_041555
    mulss xmm5, xmm2
    addss xmm4, xmm5

    ; b = 0.067871f * x
    movss xmm5, _0_067871
    mulss xmm5, xmm0

    ; b -= 0.228834f * y
    movss xmm6, _m_228834
    mulss xmm6, xmm1
    addss xmm5, xmm6

    ; b += 1.069251f * z
    movss xmm6, _1_069251
    mulss xmm6, xmm2
    addss xmm5, xmm6

    ; return r, g, b
    movss [esp + 4], xmm3
    movss [esp + 8], xmm4
    movss [esp + 12], xmm5

    ; return
    ret
    Simulator endp
    end