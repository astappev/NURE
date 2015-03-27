#ifndef TILE_H
#define TILE_H

#include <QMainWindow>
#include <QPushButton>
#include <QMessageBox>
#include <QKeyEvent>
#include <QTime>
#include <QDebug>
#include "mastile.h"

extern bool isRunning;
extern int Moves;

namespace Ui {
    class Tile;
}

class Tile : public QMainWindow, MasTile {
    Q_OBJECT

public:
    Tile(QWidget *parent = 0);

    ~Tile();

public slots:
    QPushButton* idtoButton(int id); //возвращает кнопку по id
    void clickPushButton(); //обработка нажатия
    void updateMoves(); //обновление счетчика
    void upadateButton(); //обновление кнопок

private slots: //меню
    void on_actionExit_triggered();
    void on_actionHelp_triggered();
    void on_actionAbout_triggered();
    void on_actionNew_Game_triggered();
    void on_actionReset_triggered();

private:
    Ui::Tile *ui;
};

#endif // TILE_H
