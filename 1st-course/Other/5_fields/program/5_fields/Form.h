using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;

ref struct MOVE{
	int i;
	int j;
	bool realy = false;
};

public ref class FieldsForm : public System::Windows::Forms::Form
{
public:
	FieldsForm(void)
	{
		InitializeComponent();
	}
protected:
	~FieldsForm()
	{
		if (components) delete components;
	}
private:
	Fields fields;
	MOVE prev;
	const int n = fields.n;
	array <PictureBox^, 2>^ pic; //создание масива картинок

	System::Windows::Forms::MenuStrip^  menuGame;
	System::Windows::Forms::ToolStripMenuItem^  StartGame;
	System::Windows::Forms::ToolStripMenuItem^  ExitGame;
	System::Windows::Forms::Label^  FooterLabel;
	System::ComponentModel::Container ^components;

	void InitializeComponent(void)
	{
		this->menuGame = (gcnew System::Windows::Forms::MenuStrip());
		this->StartGame = (gcnew System::Windows::Forms::ToolStripMenuItem());
		this->ExitGame = (gcnew System::Windows::Forms::ToolStripMenuItem());
		this->FooterLabel = (gcnew System::Windows::Forms::Label());
		this->menuGame->SuspendLayout();
		this->SuspendLayout();

		this->menuGame->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2) {
			this->StartGame,
			this->ExitGame
		});

		this->menuGame->Location = System::Drawing::Point(0, 0);
		this->menuGame->Name = L"menuGame";
		this->menuGame->Size = System::Drawing::Size(394, 24);
		this->menuGame->TabIndex = 0;
		this->menuGame->Text = L"menuGame";

		this->StartGame->Name = L"StartGame";
		this->StartGame->Size = System::Drawing::Size(46, 20);
		this->StartGame->Text = L"Новая игра";
		this->StartGame->Click += gcnew System::EventHandler(this, &FieldsForm::StartGame_Click);

		this->ExitGame->Name = L"ExitGame";
		this->ExitGame->Size = System::Drawing::Size(53, 20);
		this->ExitGame->Text = L"Выход";
		this->ExitGame->Click += gcnew System::EventHandler(this, &FieldsForm::ExitGame_Click);

		this->FooterLabel->Font = (gcnew System::Drawing::Font(L"Arial", 8.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
		this->FooterLabel->Location = System::Drawing::Point(33, 394);
		this->FooterLabel->Name = L"FooterLabel";
		this->FooterLabel->Size = System::Drawing::Size(339, 32);
		this->FooterLabel->TabIndex = 3;
		this->FooterLabel->Text = L"Нажмите \"Новая игра\", что бы начать игру, \"Выход\" для выхода.";

		this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
		this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
		this->BackColor = System::Drawing::Color::White;
		this->ClientSize = System::Drawing::Size(394, 430);
		this->Controls->Add(this->FooterLabel);
		this->Controls->Add(this->menuGame);
		this->MainMenuStrip = this->menuGame;
		this->Name = L"FieldsForm";
		this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
		this->Text = L"5 полей";
		this->Load += gcnew System::EventHandler(this, &FieldsForm::FieldsForm_Load);
		this->menuGame->ResumeLayout(false);
		this->menuGame->PerformLayout();
		this->ResumeLayout(false);
		this->PerformLayout();

	}

	//Функция генирации поля.
	System::Void FieldsForm_Load(System::Object^  sender, System::EventArgs^  e)
	{
		int barrier = 1; //Идентефикаторы для отступов после кубиков
		pic = gcnew array <PictureBox^, 2>(9, 9);
		for (int i = 0; i < 9; ++i)
		for (int j = 0; j < 9; ++j)
		{
			this->pic[i, j] = (gcnew System::Windows::Forms::PictureBox());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pic[i, j]))->BeginInit();

			// Задаем цвета платформ
			if (((i > n - 1) && (j > n - 1) && (i < n * 2) && (j < n * 2))) this->pic[i, j]->BackColor = System::Drawing::Color::AntiqueWhite;
			else if ((i > n - 1) && (i < n * 2)) this->pic[i, j]->BackColor = System::Drawing::Color::LightBlue;
			else if ((j > n - 1) && (j < n * 2))	this->pic[i, j]->BackColor = System::Drawing::Color::LightGreen;
			else this->pic[i, j]->BackColor = System::Drawing::Color::White;

			// Реализация отступов и положения отдельных кубиков
			this->pic[i, j]->Location = System::Drawing::Point(35 + (j * (35 + barrier)), 55 + (i * (35 + barrier)));

			this->pic[i, j]->Name = i.ToString() + j.ToString();
			this->pic[i, j]->Size = System::Drawing::Size(35, 35);
			this->pic[i, j]->TabIndex = 0;
			this->pic[i, j]->TabStop = false;
			this->Controls->Add(this->pic[i, j]);
			this->pic[i, j]->Click += gcnew System::EventHandler(this, &FieldsForm::Select_pic);
		}
	}

	// Функция клика по фишке
	System::Void Select_pic(System::Object^  sender, System::EventArgs^  e)
	{
		dynamic_cast<PictureBox^>(sender);
		int ij = Convert::ToInt32(dynamic_cast<PictureBox^>(sender)->Name);
		int i = ij / 10, j = ij % 10;

		if ((i > 2 && i < 6) || (j >2 && j < 6))
		{
			if (!prev.realy)
			{
				int move = 0;
				if (i != 8 && fields.get(i + 1, j) == 0) move++;
				if (i != 0 && fields.get(i - 1, j) == 0) move++;
				if (j != 8 && fields.get(i, j + 1) == 0) move++;
				if (j != 0 && fields.get(i, j - 1) == 0) move++;

				//Первый шаг - запоминаем
				if (fields.get(i, j) == fields.motion && move > 0)
				{
					prev.i = i, prev.j = j, prev.realy = true;
					pic[i, j]->Image = Image::FromFile("brown.gif");
				}
			}
			else
			{
				// если второй повторяет первый - обнуляем
				if (prev.i == i && prev.j == j)
				{
					prev.realy = false;
					update();
				}
				// если мы можем ходить - ходим
				else if (sqrt(pow(i - prev.i, 2) + pow(j - prev.j, 2)) == 1 && fields.get(i, j) == 0)
				{
					fields.change(prev.i, prev.j, i, j);
					prev.realy = false;
					update();
				}
				// Прыжок вверх
				else if (prev.i > i && prev.j == j && prev.i - i == 2 && fields.get(i + 1, j) == fields.next_motion())
				{
					fields.change(prev.i, prev.j, i, j);
					prev.realy = false;
					update();
				}
				// Прыжок вниз
				if (prev.i < i && prev.j == j && i - prev.i == 2 && fields.get(i - 1, j) == fields.next_motion())
				{
					fields.change(prev.i, prev.j, i, j);
					prev.realy = false;
					update();
				}
				// Прыжок влево
				if (prev.i == i && prev.j > j && prev.j - j == 2 && fields.get(i, j + 1) == fields.next_motion())
				{
					fields.change(prev.i, prev.j, i, j);
					prev.realy = false;
					update();
				}
				// Прыжок вправо
				if (prev.i == i && prev.j < j && j - prev.j == 2 && fields.get(i, j - 1) == fields.next_motion())
				{
					fields.change(prev.i, prev.j, i, j);
					prev.realy = false;
					update();
				}

				if (fields.check() == 1) MessageBox::Show("Победил Зеленый!");
				else if (fields.check() == 2) MessageBox::Show("Победил Синий!");
			}
		}
	}

	// Обновление поля, на основе массива
	System::Void update()
	{
		for (int i = 0; i < n * 3; ++i)
		for (int j = 0; j < n * 3; ++j)
		{
			if (fields.get(i, j) == 1) pic[i, j]->Image = Image::FromFile("green.gif");
			else if (fields.get(i, j) == 2) pic[i, j]->Image = Image::FromFile("blue.gif");
			else pic[i, j]->Image = nullptr;
		}

		if (fields.motion == 1) pic[8, 8]->Image = Image::FromFile("green.gif");
		else if (fields.motion == 2) pic[8, 8]->Image = Image::FromFile("blue.gif");
		else pic[8, 8]->Image = nullptr;
	}

	//Закрыть программу
	System::Void ExitGame_Click(System::Object^  sender, System::EventArgs^  e)
	{
		FieldsForm::Close();
	}

	//Новая игра
	System::Void StartGame_Click(System::Object^  sender, System::EventArgs^  e)
	{
		for (int i = 0; i < n * 3; ++i)
		for (int j = 0; j < n * 3; ++j)
			pic[i, j]->Visible = true;

		fields.play();
		update();
	}
};