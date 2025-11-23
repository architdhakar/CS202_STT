using System;
using System.Windows.Forms;

namespace OrderPipeline
{
    public partial class Form1 : Form
    {
        // Events
        public event EventHandler<OrderEventArgs> OrderCreated;
        public event EventHandler OrderRejected;
        public event EventHandler<OrderEventArgs> OrderConfirmed;
        public event EventHandler<ShipEventArgs> OrderShipped;
        private bool orderConfirmed = false;

        public Form1()
        {
            InitializeComponent();

            cmbProduct.Items.Add("Laptop");
            cmbProduct.Items.Add("Mouse");
            cmbProduct.Items.Add("Keyboard");
            cmbProduct.SelectedIndex = 0;

            // Subscribers
            OrderCreated += ValidateOrder;
            OrderCreated += DisplayOrderInfo;

            OrderRejected += ShowRejection;
            OrderConfirmed += ShowConfirmation;

            OrderShipped += ShowDispatch;

        }

        private void ShowDispatch(object sender, ShipEventArgs e)
        {
            lblStatus.Text = $"Product dispatched: {e.Product}";
        }

        private void NotifyCourier(object sender, ShipEventArgs e)
        {
            MessageBox.Show("Express shipping active. Courier notified.");
        }


        private void btnProcessOrder_Click(object sender, EventArgs e)
        {
            var args = new OrderEventArgs(
                txtCustomer.Text,
                cmbProduct.SelectedItem.ToString(),
                (int)numQuantity.Value
            );

            OrderCreated?.Invoke(this, args);
        }

        // Subscribers 

        private void ValidateOrder(object sender, OrderEventArgs e)
        {
            if (e.Quantity > 0)
            {
                lblStatus.Text = "Validated";
                OrderConfirmed?.Invoke(this, e);
            }
            else
            {
                OrderRejected?.Invoke(this, EventArgs.Empty);
            }
        }

        private void DisplayOrderInfo(object sender, OrderEventArgs e)
        {
            MessageBox.Show(
                $"Customer: {e.Customer}\nProduct: {e.Product}\nQty: {e.Quantity}",
                "Order Summary"
            );
        }

        private void ShowRejection(object sender, EventArgs e)
        {
            lblStatus.Text = "Order Invalid – Please retry";
        }

        private void ShowConfirmation(object sender, OrderEventArgs e)
        {
            lblStatus.Text = $"Order Processed Successfully for {e.Customer}";
            orderConfirmed = true;

        }

        private void btnShipOrder_Click(object sender, EventArgs e)
        {
            if (!orderConfirmed)
            {
                MessageBox.Show("Order must be processed first!");
                return;
            }

            // Manage express subscriber dynamically
            OrderShipped -= NotifyCourier;  // avoid duplication
            if (chkExpress.Checked)
                OrderShipped += NotifyCourier;

            OrderShipped?.Invoke(this, new ShipEventArgs(
                cmbProduct.SelectedItem.ToString(),
                chkExpress.Checked
            ));
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // nothing required here (just prevents errors)
        }
    }
}
