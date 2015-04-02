#include "stdafx.h"
#include "5_fields.h"
#include "Form.h"

int main()
{
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false); 
	Application::Run(gcnew FieldsForm());
	return 0;
}