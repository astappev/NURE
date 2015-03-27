#ifndef TILEUI_H
#define TILEUI_H

#include <QMainWindow>
#include <QPushButton>
#include <QMessageBox>
#include <QKeyEvent>
#include <QTime>
#include <QDebug>

#include "tile.h"

namespace Ui {
    class TileUI;
}

class TileUI : public QMainWindow, public Tile {
    Q_OBJECT
public:
    TileUI(QWidget *parent = 0);
    ~TileUI();
    //static void win();

public slots:
    QPushButton* idtoButton(int id); //возвращает кнопку по id
    void updateMoves(); //обновление счетчика
    void upadateButton(); //обновление кнопок
    int checkNeighbours();

private slots: //меню
    void on_actionExit_triggered();
    void on_actionHelp_triggered();
    void on_actionAbout_triggered();
    void on_actionNew_Game_triggered();
    void on_actionReset_triggered();

private:
    Ui::TileUI *ui;
};



#endif // TILEUI_H
