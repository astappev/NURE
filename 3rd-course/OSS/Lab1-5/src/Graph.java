/**
 * Розробити програму, яка будуватиме на екрані графіки функцій sin(x), cos(x), x за вибором користувача.
 */

import java.awt.*;
import javax.swing.*;
import javax.swing.text.html.parser.Parser;
import java.awt.event.*;
import java.awt.geom.Arc2D;
import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;

class Graph extends JFrame {
    JTextField numField;
    Integer num = 0;

    public Graph() {
        initUI();
    }

    private void initUI() {
        JPanel panel = new JPanel();
        getContentPane().add(panel);

        panel.setLayout(null);

        JLabel label = new JLabel("Введите число:");
        label.setBounds(25, 15, 225, 30);
        panel.add(label);

        numField = new JTextField();
        numField.addKeyListener(new KeyAdapter() {
            public void keyTyped(KeyEvent e) {
                char vChar = e.getKeyChar();
                if (!(Character.isDigit(vChar) || (vChar == KeyEvent.VK_BACK_SPACE) || (vChar == KeyEvent.VK_DELETE))) {
                    e.consume();
                }
            }
        });

        numField.setBounds(25, 40, 225, 30);
        panel.add(numField);

        JButton sinBtn = new JButton("sin(x)");
        sinBtn.setBounds(150, 100, 100, 30);
        sinBtn.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent event) {
                String text = numField.getText();
                if(!text.isEmpty()) {
                    num = Integer.parseInt(text);
                } else {
                    num = 0;
                }
                new GraphDraw(num, 1);
            }
        });
        sinBtn.setToolTipText("Построить график sin(x)");
        panel.add(sinBtn);

        JButton cosBtn = new JButton("cos(x)");
        cosBtn.setBounds(25, 100, 100, 30); // x, y, width, height
        cosBtn.setToolTipText("Построить график cos(x)");
        cosBtn.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent event) {
                String text = numField.getText();
                if (!text.isEmpty()) {
                    num = Integer.parseInt(text);
                } else {
                    num = 0;
                }
                new GraphDraw(num, 0);
            }
        });
        panel.add(cosBtn);

        setTitle("Ввод значения функции");
        setSize(300, 195); // width, height
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }

    public static void main(String args[]) {
        Graph mw = new Graph();
        mw.setVisible(true);
    }
}

class GraphDraw extends JFrame
{
    public GraphDraw(Integer num, Integer type)
    {
        JLabel label = new JLabel("Вы ввели число " + num.toString() + ", и выбрали " + ((type == 1) ? "синус" : "косинус") + ".");
        label.setBounds(25, 0, 350, 30);
        setLayout(new BorderLayout());
        add(label, BorderLayout.CENTER);
        add(new DrawSine(num, type), BorderLayout.CENTER);

        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        pack();

        setTitle("График функции");
        //setSize(400, 300); // width, height
        setLocationRelativeTo(null);
        setVisible(true);

        //JOptionPane.showMessageDialog(null, "Вы ввели " + num.toString() + ", можете ввести еще раз.");
    }

    class DrawSine extends JPanel {
        @Override
        public Dimension getSize() {
            return new Dimension(300,400);
        }

        @Override
        public Dimension getPreferredSize() {
            return new Dimension(300,400);
        }

        Integer num;
        Integer type;

        public DrawSine(Integer num, Integer type) {
            this.num = num;
            this.type = type;

        }

        protected void paintComponent(Graphics g) {
            super.paintComponent(g);

            g.drawLine(200, 30, 200, 190); // ось y
            g.drawLine(200, 30, 195, 40);
            g.drawLine(200, 30, 205, 40);
            g.drawString("Y", 210, 40);


            g.drawLine(0, 100, 385, 100); // ось x
            g.drawLine(385, 100, 375, 95);
            g.drawLine(385, 100, 375, 105);
            g.drawString("X", 375, 90);

            Polygon p = new Polygon();
            if(type == 1) { // синус
                for (int x = -170; x <= 170; x++) {
                    p.addPoint(x + 200, 100 - (int) (50 * Math.sin(((num + x) / 100.0) * 2 * Math.PI)));
                }
                g.setColor(Color.red);
            } else { // косинус
                for (int x = -170; x <= 170; x++) {
                    p.addPoint(x + 200, 100 - (int) (50 * Math.cos(((num + x) / 100.0) * 2 * Math.PI)));
                }
                g.setColor(Color.blue);
            }

            g.drawPolyline(p.xpoints, p.ypoints, p.npoints); // график
            g.setColor(Color.black);
            g.drawString("-2\u03c0", 95, 115); //-2pi
            g.drawString("2\u03c0", 305, 115); //2pi
            g.drawString("0", 200, 115); //0
        }
    }
}


