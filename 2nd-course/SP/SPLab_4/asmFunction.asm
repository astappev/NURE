.586
.model flat
.code
_asmFunction_ proc
public _asmFunction_
push ebp
mov ebp,esp
push ecx
push esi
push edi
push edx
mov edi,[ebp+8]
mov esi,[ebp+24]
mov ecx,[ebp+12]

beg:
	cmp byte ptr[edi], 'K'
	jne nen

	inc edi
	cmp byte ptr[edi], 'N'
	jne neno

	dec edi
	mov al, byte ptr[edi]
	mov byte ptr[esi], al
	inc edi
	inc esi

	mov al, byte ptr[edi]
	mov byte ptr[esi], al
	inc edi
	inc esi

	mov byte ptr[esi], ' '
	inc esi

	push edi
	push ecx

	mov edi, [ebp+16]
	mov ecx, [ebp+20]

	beg_vnt:
		mov al, byte ptr[edi]
		mov byte ptr[esi], al
		inc edi
		inc esi

	loop beg_vnt

	pop ecx
	pop edi
	jne nen

neno:
	dec edi
nen:
	mov al, byte ptr[edi]
	mov byte ptr[esi], al
	inc edi
	inc esi

loop beg

mov eax, esi

pop edx
pop edi
pop esi
pop ecx
pop ebp
ret
_asmFunction_ endp
end
