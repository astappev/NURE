void cppFunction(char* s, int s_size, char* result, char* insert, int insert_size)
{
	int size = 0;
	for (int i = 0; i < s_size - 1; ++i)
	{
		if (s[i] == 'K' && s[i + 1] == 'N')
		{
			result[size++] = s[i];
			result[size++] = s[i + 1];
			result[size++] = ' ';
			for (int j = 0; j < insert_size; ++j)
			{
				result[size++] = insert[j];
			}
			i += 2;
		}
		result[size++] = s[i];
	}
	result[size] = '\0';
}