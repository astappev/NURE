#include "tileUI.h"
#include "tile.h"
#include "ui_tile.h"

TileUI::TileUI(QWidget *parent):QMainWindow(parent), ui(new Ui::TileUI)
{
    ui->setupUi(this);
    ui->pushButton_16->hide();
    ui->pushButton->setProperty("id","1");
    ui->pushButton_2->setProperty("id","2");
    ui->pushButton_3->setProperty("id","3");
    ui->pushButton_4->setProperty("id","4");
    ui->pushButton_5->setProperty("id","5");
    ui->pushButton_6->setProperty("id","6");
    ui->pushButton_7->setProperty("id","7");
    ui->pushButton_8->setProperty("id","8");
    ui->pushButton_9->setProperty("id","9");
    ui->pushButton_10->setProperty("id","10");
    ui->pushButton_11->setProperty("id","11");
    ui->pushButton_12->setProperty("id","12");
    ui->pushButton_13->setProperty("id","13");
    ui->pushButton_14->setProperty("id","14");
    ui->pushButton_15->setProperty("id","15");
    ui->pushButton_16->setProperty("id","16");

    QTime time = QTime::currentTime();
    qsrand((uint)time.msec());

    qApp->installEventFilter(this);
}

void TileUI::checkNeighbours(int id)
{
    QPushButton *button = qobject_cast<QPushButton*>(QObject::sender());

    int id = button->property("id").toInt();
    Tile::checkNeighbours(--id);
    upadateButton();
    updateMoves();
}
void TileUI::upadateButton()
{
    for (int i = 0; i < Size*4; i++)
    {
        QPushButton *button = idtoButton(i+1);
        QString str;

        if (tile_mas[i] == 16) button->hide();
        else button->show();

        button->setText(str.setNum(tile_mas[i]));
    }
    qDebug()<<tile_mas[0]<<' '<<tile_mas[1]<<' '<<tile_mas[2]<<' '<<tile_mas[3]<<'\n'<<tile_mas[4]<<' '<<tile_mas[5]<<' '<<tile_mas[6]<<' '<<tile_mas[7]<<'\n'<<tile_mas[8]<<' '<<tile_mas[9]<<' '<<tile_mas[10]<<' '<<tile_mas[11]<<'\n'<<tile_mas[12]<<' '<<tile_mas[13]<<' '<<tile_mas[14]<<' '<<tile_mas[15]<<'\n'<<QTime::currentTime();
}

Tile::~TileUI()
{
    delete ui;
}

QPushButton* TileUI::idtoButton(int id)
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

void TileUI::updateMoves()
{
    QString mooves;
    ui->moves->setText(mooves.setNum(Moves));
}

void TileUI::on_actionNew_Game_triggered()
{
    Tile::NewGame();
    upadateButton();
}

void TileUI::on_actionReset_triggered()
{
    Tile::Reset();
    updateMoves();
    upadateButton();
}

void TileUI::on_actionExit_triggered()
{
    switch (QMessageBox::information(this, tr("Confirm Quit"), tr("Are you sure to quit?"), tr("&Quit"),tr("&Cancel")))
    {
        case 0:
            qApp->quit();
        default:
            break;
    }
}

void TileUI::on_actionHelp_triggered()
{
    QMessageBox::about(this, tr("15 Puzzle"), tr("\"Reset\" (Ctrl+R): reset the puzzle to begining position\n \"New Game\" (Ctrl+N): new game the puzzle\n \"Quit\" (Ctrl+Q): quit the app"));
}

void TileUI::on_actionAbout_triggered()
{
    QMessageBox::about(this, tr("Astappev Oleg"), tr("Kharkiv national university of radioelectronics\n 2013 year"));
}

void TileUI::win()
{
    switch (QMessageBox::information(TileUI::ui, tr("You Win!"), tr("\nGame again?"), tr("&Yes"),tr("&No")))
    {
        case 0:
            NewGame();
        default:
            break;
    }
}
