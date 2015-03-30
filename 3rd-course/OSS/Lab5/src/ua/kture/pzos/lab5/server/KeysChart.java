package ua.kture.pzos.lab5.server;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.axis.NumberAxis;
import org.jfree.chart.plot.CategoryPlot;
import org.jfree.chart.plot.PlotOrientation;
import org.jfree.chart.renderer.category.BarRenderer;
import org.jfree.data.category.DefaultCategoryDataset;

import javax.swing.*;
import java.util.Map;

/**
 * Created by DimaK on 20.11.2014.
 */
class KeysChart {

    // See http://www.java2s.com/Code/Java/Chart/JFreeChartBarChartDemo1.htm
    static JComponent buildJFreeChart(Map<Character, Integer> keys) {

        DefaultCategoryDataset dataset = new DefaultCategoryDataset();
        for (Map.Entry<Character, Integer> pair : keys.entrySet()) {
            dataset.addValue(pair.getValue(), "", pair.getKey());
        }

        JFreeChart chart = ChartFactory.createBarChart(
                "Key press statistics",   // chart title
                "Keys",                   // domain axis label
                "Count",                  // range axis label
                dataset,                  // data
                PlotOrientation.VERTICAL, // orientation
                false,                    // include legend
                true,                     // tooltips?
                false                     // URLs?
        );

        CategoryPlot plot = chart.getCategoryPlot();
        // set the range axis to display integers only...
        final NumberAxis rangeAxis = (NumberAxis) plot.getRangeAxis();
        rangeAxis.setStandardTickUnits(NumberAxis.createIntegerTickUnits());

        // disable bar outlines...
        BarRenderer renderer = (BarRenderer) plot.getRenderer();
        renderer.setDrawBarOutline(false);

        return new ChartPanel(chart);
    }

}
