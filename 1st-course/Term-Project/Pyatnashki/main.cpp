#include <QApplication>
#include <QTranslator>
#include "tile.h"
#include "mastile.h"

bool isRunning = 0;
int Moves = 0;

int main(int argc, char *argv[])
{
    QApplication app(argc, argv);

    QTranslator Translator;
    Translator.load(QLocale::system().name());
    app.installTranslator(&Translator);

    Tile pyatnashki;
    pyatnashki.show();

    return app.exec();
}
