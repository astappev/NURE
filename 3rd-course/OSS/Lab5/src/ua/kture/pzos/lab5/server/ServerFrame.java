package ua.kture.pzos.lab5.server;

import javax.swing.*;
import java.awt.*;
import java.util.Map;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

/**
 * Created by DimaK on 20.11.2014.
 */
class ServerFrame extends JFrame {

    private Map<Character, Integer> keys;

    ServerFrame(Map<Character, Integer> keys) {

        this.keys = keys;

        setTitle("Server");

        setSize(800, 500);
        setDefaultCloseOperation(WindowConstants.DISPOSE_ON_CLOSE); // do not stop server.
        setLocationRelativeTo(null);

        ((BorderLayout) getLayout()).setVgap(20);

        // Make an update in separate threads.
        ExecutorService executorService = Executors.newFixedThreadPool(2);
        executorService.execute(new ChartBuilder());
        executorService.execute(new TableBuilder());

    }

    private class ChartBuilder implements Runnable {
        @Override
        public void run() {
            final JComponent chart = KeysChart.buildJFreeChart(keys);
            EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    ServerFrame.this.add(chart, BorderLayout.CENTER);
                    ServerFrame.this.revalidate();
                }
            });
        }
    }

    private class TableBuilder implements Runnable {
        @Override
        public void run() {
            final JComponent table = buildTable(keys);
            EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    ServerFrame.this.add(table, BorderLayout.SOUTH);
                    ServerFrame.this.revalidate();
                }
            });
        }
    }

    private static JComponent buildTable(Map<Character, Integer> keys) {

        Object[][] rowData = new Object[keys.size()][3];
        int cntr = 0;
        for (Map.Entry<Character, Integer> pair : keys.entrySet()) {
            rowData[cntr][0] = cntr + 1;
            rowData[cntr][1] = pair.getKey();
            rowData[cntr][2] = pair.getValue();
            cntr++;
        }

        JTable table = new JTable(rowData, new String[]{
                "#", "Key", "Count"
        });
        table.setPreferredScrollableViewportSize(table.getPreferredSize());
        table.setFillsViewportHeight(true);
        return new JScrollPane(table);

    }
}
