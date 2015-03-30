import java.io.*;

public class Client2 extends Thread{

    static final int numClients = 2;

    private int id;
    private Bank bank;
    private BufferedReader in;
    private PrintStream out;

    public Client2(int id, Bank bank, BufferedReader in, PrintStream out) {
        this.id = id;
        this.bank = bank;
        this.in = in;
        this.out = out;
    }

    public void run() {
        while (true) {
            try {
                out.print("Account Id: ");
                String accountId = in.readLine();
                Account account = bank.getAccount(accountId);
                if(account == null) {
                    out.println("Account not found!");
                    return;
                } else {
                    out.println("Balance: " + account.getBalance());
                }

                out.print("Enter amount: ");
                int value = Integer.parseInt(in.readLine());
                if(account.getBalance() + value >= 0) {
                    account.post(value);
                    out.println("Balance: " + account.getBalance());
                } else {
                    throw new Exception("Not enough money!");
                }
            } catch (Exception e) {
                out.println("Error! " + e.getMessage());
            }
        }
    }

    public static void main(String[] args) throws IOException {
        Bank bank = new Bank();
        bank.addAccount(new Account("Acc001", 100));
        Client2[] clients = new Client2[numClients];
        for(int i = 0; i < numClients; ++i) {
            File inFile = new File("/home/oleg/IdeaProjects/LabPRO/src/lecture1/bank/input" + (i + 1));
            BufferedReader in = new BufferedReader(new InputStreamReader(new FileInputStream(inFile)));
            clients[i] = new Client2(i + 1, bank, in, System.out);
            clients[i].start();
        }
    }
}
