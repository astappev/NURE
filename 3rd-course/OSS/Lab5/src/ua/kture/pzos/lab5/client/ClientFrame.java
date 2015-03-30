package ua.kture.pzos.lab5.client;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.util.Map;

/**
 * Created by DimaK on 15.11.2014.
 */
class ClientFrame extends JFrame {

    private static final String SPECIAL_KEY = "CTRL_SHIFT_K";

    ClientFrame(final Map<Character, Integer> keys,
                       final KeySendListener keySendListener) throws HeadlessException {
        setTitle("Client");

        setSize(800, 500);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);

        final JPanel p = new JPanel();
        KeyStroke ctrlShiftKKeyStroke = KeyStroke.getKeyStroke(
                KeyEvent.VK_K,
                KeyEvent.CTRL_DOWN_MASK | KeyEvent.SHIFT_DOWN_MASK);
        p.getInputMap().put(ctrlShiftKKeyStroke, SPECIAL_KEY);
        p.getActionMap().put(SPECIAL_KEY, new AbstractAction() {
            @Override
            public void actionPerformed(ActionEvent e) {
                System.out.println("Action: Ctrl + alt + K is pressed");
                keySendListener.send();
            }
        });
        add(p);
        p.addKeyListener(new KeyAdapter() {
            @Override
            public void keyTyped(KeyEvent e) {
                char keyChar = e.getKeyChar();
                if (Character.isAlphabetic(keyChar)) {
                    Integer pressedCount = keys.get(keyChar);
                    if (pressedCount == null) {
                        pressedCount = 1;
                    } else {
                        pressedCount += 1;
                    }
                    keys.put(keyChar, pressedCount);
                }
            }
        });
        p.setFocusable(true);

    }
}
