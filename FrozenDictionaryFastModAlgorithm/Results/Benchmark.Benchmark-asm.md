## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
```assembly
; Benchmark.Benchmark.DefaultMod()
;         uint sum = 0;
;         ^^^^^^^^^^^^^
;         for (var i = 0; i < hashcodes.Length; i++)
;              ^^^^^^^^^
;             sum += (uint)hashcodes[i] % bucketsNum;
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
;         return sum;
;         ^^^^^^^^^^^
       sub       rsp,28
       xor       r8d,r8d
       xor       r10d,r10d
       mov       r9,[rcx+8]
       cmp       dword ptr [r9+8],0
       jle       short M00_L01
M00_L00:
       mov       rax,r9
       cmp       r10d,[rax+8]
       jae       short M00_L02
       mov       edx,r10d
       mov       eax,[rax+rdx*4+10]
       xor       edx,edx
       div       dword ptr [rcx+18]
       add       r8d,edx
       inc       r10d
       cmp       [r9+8],r10d
       jg        short M00_L00
M00_L01:
       mov       eax,r8d
       add       rsp,28
       ret
M00_L02:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 68
```

## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
```assembly
; Benchmark.Benchmark.DefaultModConst()
;         uint sum = 0;
;         ^^^^^^^^^^^^^
;         for (var i = 0; i < hashcodes.Length; i++)
;              ^^^^^^^^^
;             sum += (uint)hashcodes[i] % 14591;
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
;         return sum;
;         ^^^^^^^^^^^
       sub       rsp,28
       xor       r8d,r8d
       xor       r10d,r10d
       mov       rcx,[rcx+8]
       cmp       dword ptr [rcx+8],0
       jle       short M00_L01
M00_L00:
       mov       rax,rcx
       cmp       r10d,[rax+8]
       jae       short M00_L02
       mov       edx,r10d
       mov       r9d,[rax+rdx*4+10]
       mov       rdx,47DD54B9A0732
       mov       eax,r9d
       mul       rdx
       imul      eax,edx,38FF
       sub       r9d,eax
       add       r8d,r9d
       inc       r10d
       cmp       [rcx+8],r10d
       jg        short M00_L00
M00_L01:
       mov       eax,r8d
       add       rsp,28
       ret
M00_L02:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 88
```

## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
```assembly
; Benchmark.Benchmark.FastModDotNet()
;         uint sum = 0;
;         ^^^^^^^^^^^^^
;         for (var i = 0; i < hashcodes.Length; i++)
;              ^^^^^^^^^
;             sum += FastModDotNet((uint)hashcodes[i], multiplier, bucketsNum);
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
;         return sum;
;         ^^^^^^^^^^^
       sub       rsp,28
       xor       eax,eax
       xor       edx,edx
       mov       r8,[rcx+8]
       cmp       dword ptr [r8+8],0
       jle       short M00_L01
M00_L00:
       mov       r10,r8
       cmp       edx,[r10+8]
       jae       short M00_L02
       mov       r9d,edx
       mov       r10d,[r10+r9*4+10]
       imul      r10,[rcx+10]
       shr       r10,20
       inc       r10
       mov       r9d,[rcx+18]
       imul      r10,r9
       shr       r10,20
       add       eax,r10d
       inc       edx
       cmp       [r8+8],edx
       jg        short M00_L00
M00_L01:
       add       rsp,28
       ret
M00_L02:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 82
```

## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
```assembly
; Benchmark.Benchmark.FastModLemier()
;         uint sum = 0;
;         ^^^^^^^^^^^^^
;         for (var i = 0; i < hashcodes.Length; i++)
;              ^^^^^^^^^
;             sum += FastModLemier((uint)hashcodes[i], multiplier, bucketsNum);
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
;         return sum;
;         ^^^^^^^^^^^
       sub       rsp,28
       xor       eax,eax
       mov       [rsp+20],rax
       xor       eax,eax
       xor       r8d,r8d
       mov       rdx,[rcx+8]
       cmp       dword ptr [rdx+8],0
       jle       short M00_L01
       nop       word ptr [rax+rax]
M00_L00:
       mov       rdx,[rcx+8]
       cmp       r8d,[rdx+8]
       jae       short M00_L02
       mov       r10d,r8d
       mov       edx,[rdx+r10*4+10]
       mov       r10,[rcx+10]
       mov       r9d,[rcx+18]
       imul      rdx,r10
       mov       r10d,r9d
       lea       r9,[rsp+20]
       mulx      rdx,r11,r10
       mov       [r9],r11
       add       eax,edx
       inc       r8d
       mov       rdx,[rcx+8]
       cmp       [rdx+8],r8d
       jg        short M00_L00
M00_L01:
       add       rsp,28
       ret
M00_L02:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 104
```

