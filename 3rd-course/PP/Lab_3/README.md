## Задание
Настроить локальную версию Apache Hadoop.

## Выводы
https://mega.co.nz/#F!VQQjzDzL!0NS-7zWqid180ko2FFD3YA VirtualBox образ
В комплекте поставляется Ubuntu 14.04.1 x64 (хадуп заточен под x64) с установленым Хадупом и четвертой лабораторной.

Passwords: root:root user:user hduser:123

Soft: Hadoop 2.6.0 (/home/hduser/hadoop) Oracle Java 1.7.0_x (/usr/lib/jvm/java-7-oracle)

su hduser
ssh localhost - connecting to host
start-all.sh - for startup hadoop
stop-all.sh - for stoping hadoop ^ at terminal ;)
see more http://hadoop.apache.org/docs/current/hadoop-mapreduce-client/hadoop-mapreduce-client-core/MapReduceTutorial.html

В /home/hduser/ лежит java и class файл из примера выше. Так же эти файлы уже посчитаны лежат в дирректории Хадупа. В довнлоасе есть рузультат. Что бы забросить файл в Hadoop hadoop hdfs -put local remove Что бы достать можно воспользоваться браузером (в ФФ, закрепленная вкладка на localhost, после старта Хадупа). Или же hadoop hdfs -get remove local Больше команд: https://hadoop.apache.org/docs/r0.18.3/hdfs_shell.html

Параметры виртуальной машины выставлены под себя. Рекомендую изменить количесвто ОЗУ и видеопамяти. Диск виртульной машини весит ~8 гб, но может разростись до максимального 15 гб (следите что бы ему было свободное место на диске).

VirtalBox 4.12-93733
