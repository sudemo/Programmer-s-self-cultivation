#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <qdebug.h>
QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
signals:
    void print_signal();

private slots:
    void on_spinBox_valueChanged(int arg1);
public slots:
    void my_print();
private:
    Ui::MainWindow *ui;
};
#endif // MAINWINDOW_H
