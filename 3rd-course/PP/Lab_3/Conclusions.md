����:
��������� ��������� ������ Apache Hadoop.

������:
https://mega.co.nz/#F!VQQjzDzL!0NS-7zWqid180ko2FFD3YA
VirtualBox ����� ^

� ��������� ������������ Ubuntu 14.04.1 x64 (����� ������� ��� x64) � ������������ ������� � ��������� ������������.

Passwords:
	root:root
	user:user
	hduser:123

Soft:
	Hadoop 2.6.0 (/home/hduser/hadoop)
	Oracle Java 1.7.0_x (/usr/lib/jvm/java-7-oracle)

0. su hduser
1. ssh localhost - connecting to host
2. start-all.sh - for startup hadoop
3. stop-all.sh - for stoping hadoop
^ at terminal ;)

see more http://hadoop.apache.org/docs/current/hadoop-mapreduce-client/hadoop-mapreduce-client-core/MapReduceTutorial.html

� /home/hduser/ ����� java � class ���� �� ������� ����. ��� �� ��� ����� ��� ��������� ����� � ����������� ������. � ��������� ���� ���������.
��� �� ��������� ���� � Hadoop
hadoop hdfs -put local remove
��� �� ������� ����� ��������������� ��������� (� ��, ������������ ������� �� localhost, ����� ������ ������).
��� ��
hadoop hdfs -get remove local
������ ������:
https://hadoop.apache.org/docs/r0.18.3/hdfs_shell.html

��������� ����������� ������ ���������� ��� ����. ���������� �������� ���������� ��� � �����������. ���� ���������� ������ ����� ~8 ��, �� ����� ���������� �� ������������� 15 �� (������� ��� �� ��� ���� ��������� ����� �� �����).

VirtalBox 4.12-93733