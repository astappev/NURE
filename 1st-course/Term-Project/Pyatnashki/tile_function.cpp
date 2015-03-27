#include "tile.h"
#include "mastile.h"
#include "ui_tile.h"

Tile::Tile(QWidget *parent):QMainWindow(parent), ui(new Ui::Tile)
{
    ui->setupUi(this);
    ui->pushButton_16->hide();
    ui->pushButton->setProperty("id","0");
    ui->pushButton_2->setProperty("id","1");
    ui->pushButton_3->setProperty("id","2");
    ui->pushButton_4->setProperty("id","3");
    ui->pushButton_5->setProperty("id","4");
    ui->pushButton_6->setProperty("id","5");
    ui->pushButton_7->setProperty("id","6");
    ui->pushButton_8->setProperty("id","7");
    ui->pushButton_9->setProperty("id","8");
    ui->pushButton_10->setProperty("id","9");
    ui->pushButton_11->setProperty("id","10");
    ui->pushButton_12->setProperty("id","11");
    ui->pushButton_13->setProperty("id","12");
    ui->pushButton_14->setProperty("id","13");
    ui->pushButton_15->setProperty("id","14");
    ui->pushButton_16->setProperty("id","15");

    QTime time = QTime::currentTime();
    qsrand((uint)time.msec());

    qApp->installEventFilter(this);
}

void Tile::upadateButton()
{
    for (int i = 0; i < Size*4; i++)
    {
        QPushButton *button = idtoButton(i+1);
        QString str;

        if (getTile(i) == 16) button->hide();
        else button->show();

        button->setText(str.setNum(getTile(i)));
    }
}

Tile::~Tile()
{
    delete ui;
}

QPushButton* Tile::idtoButton(int id)
{
    switch (id)
    {
        case 1:
            return ui->pushButton;
        case 2:
            return ui->pushButton_2;
        case 3:
            return ui->pushButton_3;
        case 4:
            return ui->pushButton_4;
        case 5:
            return ui->pushButton_5;
        case 6:
            return ui->pushButton_6;
        case 7:
            return ui->pushButton_7;
        case 8:
            return ui->pushButton_8;
        case 9:
            return ui->pushButton_9;
        case 10:
            return ui->pushButton_10;
        case 11:
            return ui->pushButton_11;
        case 12:
            return ui->pushButton_12;
        case 13:
            return ui->pushButton_13;
        case 14:
            return ui->pushButton_14;
        case 15:
            return ui->pushButton_15;
        case 16:
            return ui->pushButton_16;
        default:
            break;
    }
    return NULL;
}

void Tile::clickPushButton()
{
    QPushButton *button = qobject_cast<QPushButton*>(QObject::sender());
    int id = button->property("id").toInt();

    checkNeighbours(id);
    upadateButton();
    updateMoves();

    if (isRunning && isWin())
    {
        isRunning = 0;
        switch (QMessageBox::information(this, tr("You Win!"), tr("\nGame again?"), tr("&Yes"),tr("&No")))
        {
            case 0:
                NewGame();
            default:
                break;
        }
    }
}

void Tile::updateMoves()
{
    QString mooves;
    ui->moves->setText(mooves.setNum(Moves));
}

void Tile::on_actionNew_Game_triggered()
{
    NewGame();
    upadateButton();
}

void Tile::on_actionReset_triggered()
{
    Reset();
    updateMoves();
    upadateButton();
}

void Tile::on_actionExit_triggered()
{
    switch (QMessageBox::information(this, tr("Confirm Quit"), tr("Are you sure to quit?"), tr("&Quit"),tr("&Cancel")))
    {
        case 0:
            qApp->quit();
        default:
            break;
    }
}

void Tile::on_actionHelp_triggered()
{
    QMessageBox::about(this, tr("15 Puzzle"), tr("\"Reset\" (Ctrl+R): reset the puzzle to begining position\n \"New Game\" (Ctrl+N): new game the puzzle\n \"Quit\" (Ctrl+Q): quit the app"));
}

void Tile::on_actionAbout_triggered()
{
    QMessageBox::about(this, tr("Astappev Oleg"), tr("Kharkiv national university of radioelectronics\n 2013 year"));
}

int MasTile::getTile(int id)
{
    if (id >= 0 && id <= 16)
        return tile_mas[id];
    else
        return 0;
}

void MasTile::checkNeighbours(int id)
{
    if (id != 15 && id != 11 && id != 7 && id != 3)
    {
        if (tile_mas[id+1] == 16)
        {
            swapButtons(id, id+1);
            return;
        }
    }

    if (id != 12 && id != 8 && id != 4 && id != 0)
    {
        if (tile_mas[id-1] == 16)
        {
            swapButtons(id, id-1);
            return;
        }
    }

    if (id != 15 && id != 14 && id != 13 && id != 12)
    {
        if (tile_mas[id+4] == 16)
        {
            swapButtons(id, id+4);
            return;
        }
    }

    if (id != 3 && id != 2 && id != 1 && id != 0)
    {
        if (tile_mas[id-4] == 16)
        {
            swapButtons(id, id-4);
            return;
        }
    }
    return;
}

void MasTile::swapButtons(int id, int to_id)
{
    int tmp = tile_mas[id];
    tile_mas[id] = tile_mas[to_id];
    tile_mas[to_id] = tmp;

    if (isRunning)
    {
        Moves++;
    }
}

void MasTile::Reset()
{
    isRunning = 0;
    Moves = 0;

    for (int i = 0; i < Size*4; i++)
    {
        tile_mas[i] = i+1;
    }
}

void MasTile::NewGame()
{
    Reset();
    for (int i = 0; i < Size*4; i++)
    {
        int id = randInt(0,15);

        int tmp = tile_mas[i];
        tile_mas[i] = tile_mas[id];
        tile_mas[id] = tmp;
    }
    if (!isSolvable())
    {
        NewGame();
    }
    else
    {
        isRunning = 1;
    }
}

int MasTile::randInt(int min, int max)
{
    return qrand() % ((max + 1) - min) + min;
}

bool MasTile::isSolvable()
{
    int acc = 0;
    for (int i = 0; i < Size*4; i++)
    {
        int num = tile_mas[i];
        if (num == 16)
        {
            if (i < Size) acc += 1;
            else if (i < Size*2) acc += 2;
            else if (i < Size*3) acc += 3;
            else acc += 4;
            continue;
        }

        for (int j = i; j < Size*4; j++)
        {
            int num_next = tile_mas[j];
            if (num_next < num) acc++;
        }
    }
    if (acc%2 == 0)
        return 1;
    else
        return 0;
}

bool MasTile::isWin()
{
    for (int i = 0; i < Size*4; i++)
    {
        if (tile_mas[i] != i+1)
        {
            return 0;
        }
    }
    return 1;
}
