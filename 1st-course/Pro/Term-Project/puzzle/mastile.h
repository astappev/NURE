#ifndef MASTILE_H
#define MASTILE_H

class MasTile{
public:
    static const int Size = 4;

    int getTile(int id);
    void checkNeighbours(int id); //проверка соседей, в частности существует ли среди них 16
    void swapButtons(int id, int to_id); //обмен местаими
    void Reset(); //сбросить на расстановку по умолчанию
    void NewGame(); //раздать рандомные перестановки
    int randInt(int min, int max); //рандом растановка
    bool isSolvable(); //правильно ли разложено
    bool isWin(); //все ли сложено верно

private:
    int tile_mas[Size*4];
};

#endif // MASTILE_H
