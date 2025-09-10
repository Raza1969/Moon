using KamalPashFabricsC_Sharp;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KamalPashFabricsC_Sharp
{
    public partial class QuotationForm : Form
    {
        // ==========================================
        // SECTION 1: FIELD DECLARATIONS
        // ==========================================

        // Header controls
        private Panel blueHeaderPanel;
        private Panel pinkHeaderPanel;
        private Label lblQuotationTitle;
        private Button btnSavePreview, btnEditPreview, btnRefresh, btnSelectQuotation, btnPreparedBy, btnEditedBy;
        private Panel btnInitialBox, btnNewInitialBox; // Changed from Button to Panel
        private Label lblQuotationNo;
        private Button btnQuotationNo, btnCopy;

        // Left Side Quotation Fields
        private Panel leftFieldsPanel;
        private Label lblCustomer, lblContactPerson, lblDepartment, lblEmail, lblMobile, lblReference, lblSubject, lblNote;
        private TextBox txtCustomer, txtContactPerson, txtDepartment, txtEmail, txtMobile, txtReference, txtSubject, txtNote;

        // Right side panel for date controls
        private Panel rightFieldsPanel;

        // Right side controls
        private DateTimePicker dateTimePicker;
        private Label lblDate;
        private Label colonDate;
        private Label lblCurrency;
        private Label colonCurrency;
        private TextBox txtCurrency;
        private Button btnCurrencyDropdown; // Currency dropdown button
        private Label lblTaxable;
        private Label colonTaxable;
        private CheckBox chkTaxable;
        private Label lblAmountWOGST;
        private Label colonAmountWOGST;
        private TextBox txtAmountWOGST;
        private Label lblGST;
        private Label colonGST;
        private TextBox txtGST;
        private Label lblAmountWithGST;
        private Label colonAmountWithGST;
        private TextBox txtAmountWithGST;
        private Label lblDiscount; // Discount label
        private TextBox txtDiscount; // Discount textbox
        private Button btnDiscountDropdown; // Discount dropdown button

        // Form state management
        private bool isFormInitialized = false;
        private Size originalFormSize = new Size(1200, 600);

        // ==========================================
        // SECTION 2: CONSTRUCTOR
        // ==========================================

        public QuotationForm()
        {
            InitializeComponent();
            SetupForm();
            CreateHeaderPanels();
            CreateLeftFieldsPanel();
            AddQuoteDateControls();
            SetDefaultCurrency(); // Add default currency
            isFormInitialized = true;
        }

        // ==========================================
        // SECTION 3: BASIC FORM INITIALIZATION
        // ==========================================

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Text = "Kamal Pasha Fabrics - Quotation";
            this.Size = originalFormSize;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimumSize = new Size(1000, 600);
            this.MaximumSize = new Size(1400, 800);
            this.ResumeLayout(false);
        }

        private void SetupForm()
        {
            this.Text = "Kamal Pasha Fabrics - Quotation";
        }

        // ==========================================
        // SECTION 4: COMPLETE HEADER PANELS CREATION
        // ==========================================

        private void CreateHeaderPanels()
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            Color pink = ColorTranslator.FromHtml("#f8bbd0");
            Font btnFont = new Font("Arial", 11, FontStyle.Bold);

            // Create Blue Header Panel
            blueHeaderPanel = new Panel
            {
                BackColor = blue,
                Height = 35,
                Dock = DockStyle.Top
            };

            // Create Pink Header Panel
            int pinkBarHeight = 44;
            pinkHeaderPanel = new Panel
            {
                BackColor = pink,
                Height = pinkBarHeight,
                Dock = DockStyle.Top
            };

            int buttonHeight = 32;
            int buttonWidth = 145;
            int buttonY = (pinkBarHeight - buttonHeight) / 2;

            // Save + Preview Button
            btnSavePreview = new Button
            {
                Text = "Save + Preview",
                Size = new Size(buttonWidth, buttonHeight),
                Location = new Point(20, buttonY),
                Font = btnFont,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = blue,
                Padding = new Padding(0),
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnSavePreview.FlatAppearance.BorderColor = blue;
            btnSavePreview.FlatAppearance.BorderSize = 2;
            btnSavePreview.FlatAppearance.MouseDownBackColor = pink;
            btnSavePreview.FlatAppearance.MouseOverBackColor = pink;
            btnSavePreview.MouseEnter += BtnSavePreview_MouseEnter;
            btnSavePreview.MouseLeave += BtnSavePreview_MouseLeave;

            // Edit + Preview Button
            btnEditPreview = new Button
            {
                Text = "Edit + Preview",
                Size = new Size(buttonWidth, buttonHeight),
                Location = new Point(175, buttonY),
                Font = btnFont,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = blue,
                Padding = new Padding(0),
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnEditPreview.FlatAppearance.BorderColor = blue;
            btnEditPreview.FlatAppearance.BorderSize = 2;
            btnEditPreview.FlatAppearance.MouseDownBackColor = pink;
            btnEditPreview.FlatAppearance.MouseOverBackColor = pink;
            btnEditPreview.MouseEnter += BtnEditPreview_MouseEnter;
            btnEditPreview.MouseLeave += BtnEditPreview_MouseLeave;

            // Refresh Button
            btnRefresh = new Button
            {
                Text = "Refresh",
                Size = new Size(110, buttonHeight),
                Location = new Point(330, buttonY),
                Font = btnFont,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = blue,
                Padding = new Padding(0),
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnRefresh.FlatAppearance.BorderColor = blue;
            btnRefresh.FlatAppearance.BorderSize = 2;
            btnRefresh.FlatAppearance.MouseDownBackColor = pink;
            btnRefresh.FlatAppearance.MouseOverBackColor = pink;
            btnRefresh.MouseEnter += BtnRefresh_MouseEnter;
            btnRefresh.MouseLeave += BtnRefresh_MouseLeave;

            // Quotation Number Label and Button
            lblQuotationNo = new Label
            {
                Text = "Quotation No.",
                Font = btnFont,
                ForeColor = blue,
                AutoSize = true
            };

            btnQuotationNo = new Button();
            DateTime now = DateTime.Now;
            string quotationNumber = now.ToString("yyMMdd") + "01";
            btnQuotationNo.Text = quotationNumber;
            btnQuotationNo.Size = new Size(90, buttonHeight);
            btnQuotationNo.Font = new Font("Arial", 12, FontStyle.Bold);
            btnQuotationNo.FlatStyle = FlatStyle.Flat;
            btnQuotationNo.BackColor = Color.White;
            btnQuotationNo.ForeColor = blue;
            btnQuotationNo.FlatAppearance.BorderColor = blue;
            btnQuotationNo.FlatAppearance.BorderSize = 2;
            btnQuotationNo.TextAlign = ContentAlignment.MiddleCenter;
            btnQuotationNo.Enabled = true;

            // Select Quotation Button
            btnSelectQuotation = new Button
            {
                Text = "Select Quotation ▼",
                Font = btnFont,
                Size = new Size(160, buttonHeight),
                BackColor = Color.White,
                ForeColor = blue,
                FlatStyle = FlatStyle.Flat,
                TabStop = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnSelectQuotation.FlatAppearance.BorderColor = blue;
            btnSelectQuotation.FlatAppearance.BorderSize = 2;
            btnSelectQuotation.FlatAppearance.MouseOverBackColor = pink;
            btnSelectQuotation.MouseEnter += BtnSelectQuotation_MouseEnter;
            btnSelectQuotation.MouseLeave += BtnSelectQuotation_MouseLeave;
            btnSelectQuotation.Click += BtnSelectQuotation_Click;

            // Quotation Title Label
            lblQuotationTitle = new Label
            {
                Text = "Quotation",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Prepared By Button
            btnPreparedBy = new Button
            {
                Text = "Prepared By ▼",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Size = new Size(140, 28),
                BackColor = Color.White,
                ForeColor = blue,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(0)
            };
            btnPreparedBy.FlatAppearance.BorderColor = pink;
            btnPreparedBy.FlatAppearance.BorderSize = 2;
            btnPreparedBy.MouseEnter += BtnPreparedBy_MouseEnter;
            btnPreparedBy.MouseLeave += BtnPreparedBy_MouseLeave;
            btnPreparedBy.Click += BtnPreparedBy_Click;

            // Edited By Button
            btnEditedBy = new Button
            {
                Text = "Edited By ▼",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Size = new Size(120, 28),
                BackColor = Color.White,
                ForeColor = blue,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(0)
            };
            btnEditedBy.FlatAppearance.BorderColor = pink;
            btnEditedBy.FlatAppearance.BorderSize = 2;
            btnEditedBy.MouseEnter += BtnEditedBy_MouseEnter;
            btnEditedBy.MouseLeave += BtnEditedBy_MouseLeave;
            btnEditedBy.Click += BtnEditedBy_Click;

            // Initial Box Button - PANEL WITH TEXTBOX APPROACH (Width 90 + Complete Bold Pink Border)
            btnInitialBox = new Panel
            {
                Width = 90,
                Height = 28,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            btnInitialBox.Paint += (s, e) =>
            {
                using (var pen = new Pen(ColorTranslator.FromHtml("#f8bbd0"), 3))
                {
                    // Draw all four sides separately to ensure complete bold border
                    e.Graphics.DrawLine(pen, 0, 0, btnInitialBox.Width - 1, 0); // Top
                    e.Graphics.DrawLine(pen, 0, 0, 0, btnInitialBox.Height - 1); // Left
                    e.Graphics.DrawLine(pen, btnInitialBox.Width - 1, 0, btnInitialBox.Width - 1, btnInitialBox.Height - 1); // Right
                    e.Graphics.DrawLine(pen, 0, btnInitialBox.Height - 1, btnInitialBox.Width - 1, btnInitialBox.Height - 1); // Bottom
                }
            };

            // Add TextBox inside Initial Box Panel (Center Aligned)
            TextBox txtInitialBox = new TextBox
            {
                Text = "",
                Font = new Font("Arial", 9, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = ColorTranslator.FromHtml("#0d47a1"),
                BorderStyle = BorderStyle.None,
                Left = 2,
                Top = 6,
                Width = 86,
                Height = 22,
                TextAlign = HorizontalAlignment.Center,
                ReadOnly = true,
                Anchor = AnchorStyles.None
            };
            btnInitialBox.Controls.Add(txtInitialBox);

            // New Initial Box Button - PANEL WITH TEXTBOX APPROACH (Width 90 + Complete Bold Pink Border)
            btnNewInitialBox = new Panel
            {
                Width = 90,
                Height = 28,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            btnNewInitialBox.Paint += (s, e) =>
            {
                using (var pen = new Pen(ColorTranslator.FromHtml("#f8bbd0"), 3))
                {
                    // Draw all four sides separately to ensure complete bold border
                    e.Graphics.DrawLine(pen, 0, 0, btnNewInitialBox.Width - 1, 0); // Top
                    e.Graphics.DrawLine(pen, 0, 0, 0, btnNewInitialBox.Height - 1); // Left
                    e.Graphics.DrawLine(pen, btnNewInitialBox.Width - 1, 0, btnNewInitialBox.Width - 1, btnNewInitialBox.Height - 1); // Right
                    e.Graphics.DrawLine(pen, 0, btnNewInitialBox.Height - 1, btnNewInitialBox.Width - 1, btnNewInitialBox.Height - 1); // Bottom
                }
            };

            // Add TextBox inside New Initial Box Panel (Center Aligned)
            TextBox txtNewInitialBox = new TextBox
            {
                Text = "",
                Font = new Font("Arial", 9, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = ColorTranslator.FromHtml("#0d47a1"),
                BorderStyle = BorderStyle.None,
                Left = 2,
                Top = 6,
                Width = 86,
                Height = 22,
                TextAlign = HorizontalAlignment.Center,
                ReadOnly = true,
                Anchor = AnchorStyles.None
            };
            btnNewInitialBox.Controls.Add(txtNewInitialBox);

            // Copy Button
            btnCopy = new Button
            {
                Text = "Copy",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Size = new Size(90, 28),
                BackColor = Color.White,
                ForeColor = blue,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(0),
            };
            btnCopy.FlatAppearance.BorderColor = pink;
            btnCopy.FlatAppearance.BorderSize = 2;
            btnCopy.MouseEnter += BtnCopy_MouseEnter;
            btnCopy.MouseLeave += BtnCopy_MouseLeave;
            btnCopy.Click += BtnCopy_Click;

            // Quote and Terms Buttons
            int quoteTermsBtnWidth = 70;
            int quoteTermsBtnHeight = 28;
            int quoteTermsBtnY = (blueHeaderPanel.Height - quoteTermsBtnHeight) / 2;
            int quoteTermsGap = 5;
            int quoteTermsStartX = btnEditPreview.Left;

            Button btnQuote = new Button
            {
                Text = "Quote",
                Font = btnFont,
                Size = new Size(quoteTermsBtnWidth, quoteTermsBtnHeight),
                BackColor = Color.White,
                ForeColor = blue,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(quoteTermsStartX, quoteTermsBtnY),
                Padding = new Padding(0)
            };
            btnQuote.FlatAppearance.BorderColor = pink;
            btnQuote.FlatAppearance.BorderSize = 2;
            btnQuote.MouseEnter += (s, e) => {
                btnQuote.BackColor = blue;
                btnQuote.ForeColor = Color.White;
            };
            btnQuote.MouseLeave += (s, e) => {
                btnQuote.BackColor = Color.White;
                btnQuote.ForeColor = blue;
            };

            Button btnTerms = new Button
            {
                Text = "Terms",
                Font = btnFont,
                Size = new Size(quoteTermsBtnWidth, quoteTermsBtnHeight),
                BackColor = Color.White,
                ForeColor = blue,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(quoteTermsStartX + quoteTermsBtnWidth + quoteTermsGap, quoteTermsBtnY),
                Padding = new Padding(0)
            };
            btnTerms.FlatAppearance.BorderColor = pink;
            btnTerms.FlatAppearance.BorderSize = 2;
            btnTerms.MouseEnter += (s, e) => {
                btnTerms.BackColor = blue;
                btnTerms.ForeColor = Color.White;
            };
            btnTerms.MouseLeave += (s, e) => {
                btnTerms.BackColor = Color.White;
                btnTerms.ForeColor = blue;
            };

            // Add event handlers
            this.Load += QuotationForm_Load;
            this.Resize += QuotationForm_Resize;
            this.Shown += QuotationForm_Shown;

            // Add controls to pink header panel
            pinkHeaderPanel.Controls.Add(btnSavePreview);
            pinkHeaderPanel.Controls.Add(btnEditPreview);
            pinkHeaderPanel.Controls.Add(btnRefresh);
            pinkHeaderPanel.Controls.Add(lblQuotationNo);
            pinkHeaderPanel.Controls.Add(btnQuotationNo);
            pinkHeaderPanel.Controls.Add(btnSelectQuotation);

            // Add controls to blue header panel
            blueHeaderPanel.Controls.Add(lblQuotationTitle);
            blueHeaderPanel.Controls.Add(btnPreparedBy);
            blueHeaderPanel.Controls.Add(btnInitialBox);
            blueHeaderPanel.Controls.Add(btnEditedBy);
            blueHeaderPanel.Controls.Add(btnNewInitialBox);
            blueHeaderPanel.Controls.Add(btnCopy);
            blueHeaderPanel.Controls.Add(btnQuote);
            blueHeaderPanel.Controls.Add(btnTerms);

            // Add panels to form
            this.Controls.Add(pinkHeaderPanel);
            this.Controls.Add(blueHeaderPanel);
        }

        // ==========================================
        // SECTION 5: COPY BUTTON EVENT HANDLERS
        // ==========================================

        private void BtnCopy_MouseEnter(object sender, EventArgs e)
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnCopy.BackColor = blue;
            btnCopy.ForeColor = Color.White;
        }

        private void BtnCopy_MouseLeave(object sender, EventArgs e)
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnCopy.BackColor = Color.White;
            btnCopy.ForeColor = blue;
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            if (btnQuotationNo != null && !string.IsNullOrEmpty(btnQuotationNo.Text))
            {
                Clipboard.SetText(btnQuotationNo.Text);
                MessageBox.Show("Quotation number copied to clipboard!", "Copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ==========================================
        // SECTION 6: LEFT FIELDS PANEL CREATION
        // ==========================================

        private void CreateLeftFieldsPanel()
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            Color pink = ColorTranslator.FromHtml("#f8bbd0");

            leftFieldsPanel = new Panel
            {
                Location = new Point(30, pinkHeaderPanel.Height + blueHeaderPanel.Height + 15),
                Size = new Size(680, 420),
                BackColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom
            };

            Font labelFont = new Font("Arial", 10, FontStyle.Bold);
            Font colonFont = new Font("Arial", 10, FontStyle.Bold);
            Font textFont = new Font("Arial", 10, FontStyle.Regular);

            int lblWidth = 120;
            int colonWidth = 10;
            int colonX = 10 + lblWidth + 6;
            int txtX = colonX + colonWidth + 12;
            int txtWidth = 405;
            int height = 28;
            int gap = 10;

            // Customer Name Field
            lblCustomer = new Label
            {
                Text = "Customer Name",
                Font = labelFont,
                ForeColor = blue,
                Location = new Point(10, 10),
                Size = new Size(lblWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Label colonCustomer = new Label
            {
                Text = ":",
                Font = colonFont,
                ForeColor = blue,
                Location = new Point(colonX, 10),
                Size = new Size(colonWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            txtCustomer = new TextBox
            {
                Font = textFont,
                Location = new Point(txtX, 10),
                Size = new Size(txtWidth, height)
            };

            Button btnSelectCustomer = new Button
            {
                Text = "▼",
                Font = new Font("Arial", 9, FontStyle.Bold),
                Size = new Size(height, txtCustomer.Height),
                Location = new Point(txtX + txtWidth + 5, 10),
                BackColor = Color.White,
                ForeColor = blue,
                FlatStyle = FlatStyle.Flat,
                TabStop = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Padding = new Padding(0)
            };
            btnSelectCustomer.FlatAppearance.BorderColor = blue;
            btnSelectCustomer.FlatAppearance.BorderSize = 2;
            btnSelectCustomer.FlatAppearance.MouseOverBackColor = pink;
            btnSelectCustomer.MouseEnter += (s, e) => {
                btnSelectCustomer.BackColor = pink;
                btnSelectCustomer.ForeColor = Color.White;
            };
            btnSelectCustomer.MouseLeave += (s, e) => {
                btnSelectCustomer.BackColor = Color.White;
                btnSelectCustomer.ForeColor = blue;
            };
            btnSelectCustomer.Click += (s, e) => {
                MessageBox.Show("Customer selection dropdown open hoga yahan!", "Select Customer");
            };

            // Contact Person Field
            lblContactPerson = new Label
            {
                Text = "Contact Person",
                Font = labelFont,
                ForeColor = blue,
                Location = new Point(10, 10 + (height + gap) * 1),
                Size = new Size(lblWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Label colonContactPerson = new Label
            {
                Text = ":",
                Font = colonFont,
                ForeColor = blue,
                Location = new Point(colonX, 10 + (height + gap) * 1),
                Size = new Size(colonWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            txtContactPerson = new TextBox
            {
                Font = textFont,
                Location = new Point(txtX, 10 + (height + gap) * 1),
                Size = new Size(txtWidth, height)
            };

            // Department Field
            lblDepartment = new Label
            {
                Text = "Department",
                Font = labelFont,
                ForeColor = blue,
                Location = new Point(10, 10 + (height + gap) * 2),
                Size = new Size(lblWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Label colonDepartment = new Label
            {
                Text = ":",
                Font = colonFont,
                ForeColor = blue,
                Location = new Point(colonX, 10 + (height + gap) * 2),
                Size = new Size(colonWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            txtDepartment = new TextBox
            {
                Font = textFont,
                Location = new Point(txtX, 10 + (height + gap) * 2),
                Size = new Size(txtWidth, height)
            };

            // Email Field
            lblEmail = new Label
            {
                Text = "Email",
                Font = labelFont,
                ForeColor = blue,
                Location = new Point(10, 10 + (height + gap) * 3),
                Size = new Size(lblWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Label colonEmail = new Label
            {
                Text = ":",
                Font = colonFont,
                ForeColor = blue,
                Location = new Point(colonX, 10 + (height + gap) * 3),
                Size = new Size(colonWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            txtEmail = new TextBox
            {
                Font = textFont,
                Location = new Point(txtX, 10 + (height + gap) * 3),
                Size = new Size(txtWidth, height)
            };

            // Mobile Field
            lblMobile = new Label
            {
                Text = "Mobile",
                Font = labelFont,
                ForeColor = blue,
                Location = new Point(10, 10 + (height + gap) * 4),
                Size = new Size(lblWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Label colonMobile = new Label
            {
                Text = ":",
                Font = colonFont,
                ForeColor = blue,
                Location = new Point(colonX, 10 + (height + gap) * 4),
                Size = new Size(colonWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            txtMobile = new TextBox
            {
                Font = textFont,
                Location = new Point(txtX, 10 + (height + gap) * 4),
                Size = new Size(txtWidth, height)
            };

            // Reference Field
            lblReference = new Label
            {
                Text = "Reference",
                Font = labelFont,
                ForeColor = blue,
                Location = new Point(10, 10 + (height + gap) * 5),
                Size = new Size(lblWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Label colonReference = new Label
            {
                Text = ":",
                Font = colonFont,
                ForeColor = blue,
                Location = new Point(colonX, 10 + (height + gap) * 5),
                Size = new Size(colonWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            txtReference = new TextBox
            {
                Font = textFont,
                Location = new Point(txtX, 10 + (height + gap) * 5),
                Size = new Size(txtWidth, height)
            };

            // Subject Field
            lblSubject = new Label
            {
                Text = "Subject",
                Font = labelFont,
                ForeColor = blue,
                Location = new Point(10, 10 + (height + gap) * 6),
                Size = new Size(lblWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Label colonSubject = new Label
            {
                Text = ":",
                Font = colonFont,
                ForeColor = blue,
                Location = new Point(colonX, 10 + (height + gap) * 6),
                Size = new Size(colonWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            txtSubject = new TextBox
            {
                Font = textFont,
                Location = new Point(txtX, 10 + (height + gap) * 6),
                Size = new Size(txtWidth, height)
            };

            // Note Field (Multiline)
            lblNote = new Label
            {
                Text = "Note",
                Font = labelFont,
                ForeColor = blue,
                Location = new Point(10, 10 + (height + gap) * 7),
                Size = new Size(lblWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Label colonNote = new Label
            {
                Text = ":",
                Font = colonFont,
                ForeColor = blue,
                Location = new Point(colonX, 10 + (height + gap) * 7),
                Size = new Size(colonWidth, height),
                TextAlign = ContentAlignment.MiddleLeft
            };
            txtNote = new TextBox
            {
                Font = textFont,
                Location = new Point(txtX, 10 + (height + gap) * 7),
                Size = new Size(txtWidth, height * 2),
                Multiline = true
            };

            // Add all controls to left fields panel
            leftFieldsPanel.Controls.Add(lblCustomer);
            leftFieldsPanel.Controls.Add(colonCustomer);
            leftFieldsPanel.Controls.Add(txtCustomer);
            leftFieldsPanel.Controls.Add(btnSelectCustomer);

            leftFieldsPanel.Controls.Add(lblContactPerson);
            leftFieldsPanel.Controls.Add(colonContactPerson);
            leftFieldsPanel.Controls.Add(txtContactPerson);

            leftFieldsPanel.Controls.Add(lblDepartment);
            leftFieldsPanel.Controls.Add(colonDepartment);
            leftFieldsPanel.Controls.Add(txtDepartment);

            leftFieldsPanel.Controls.Add(lblEmail);
            leftFieldsPanel.Controls.Add(colonEmail);
            leftFieldsPanel.Controls.Add(txtEmail);

            leftFieldsPanel.Controls.Add(lblMobile);
            leftFieldsPanel.Controls.Add(colonMobile);
            leftFieldsPanel.Controls.Add(txtMobile);

            leftFieldsPanel.Controls.Add(lblReference);
            leftFieldsPanel.Controls.Add(colonReference);
            leftFieldsPanel.Controls.Add(txtReference);

            leftFieldsPanel.Controls.Add(lblSubject);
            leftFieldsPanel.Controls.Add(colonSubject);
            leftFieldsPanel.Controls.Add(txtSubject);

            leftFieldsPanel.Controls.Add(lblNote);
            leftFieldsPanel.Controls.Add(colonNote);
            leftFieldsPanel.Controls.Add(txtNote);

            this.Controls.Add(leftFieldsPanel);
        }

        // ==========================================
        // SECTION 7: QUOTE DATE CONTROLS (WITH DEFAULT CURRENCY)
        // ==========================================

        private void AddQuoteDateControls()
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            Color pink = ColorTranslator.FromHtml("#f8bbd0");
            Font rightSideLabelFont = new Font("Arial", 10, FontStyle.Bold);

            rightFieldsPanel = new Panel
            {
                Location = new Point(this.ClientSize.Width - 380, pinkHeaderPanel.Height + blueHeaderPanel.Height + 30),
                Size = new Size(350, 420),
                BackColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom
            };

            int labelWidth = 120;
            int colonWidth = 10;
            int labelX = 10;
            int colonGap = 6;
            int colonX = labelX + labelWidth + colonGap;

            // Currency controls ke liye measurements
            int currencyTextBoxWidth = 132; // Width kam ki (160 - 28 = 132)
            int dropdownButtonWidth = 28;   // Customer dropdown jaisi width
            int textBoxX = 160;
            int dropdownX = textBoxX + currencyTextBoxWidth; // TextBox ke right side

            int startY = 10;
            int verticalGap = 35;

            // Date Label, Colon, DateTimePicker
            lblDate = new Label
            {
                Text = "Date",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(labelX, startY + 5),
                Size = new Size(labelWidth, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };
            colonDate = new Label
            {
                Text = ":",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(colonX, startY + 5),
                Size = new Size(colonWidth, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            dateTimePicker = new DateTimePicker
            {
                Font = new Font("Arial", 9, FontStyle.Regular),
                ForeColor = blue,
                Size = new Size(160, 28),
                Location = new Point(textBoxX, startY),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd-MM-yyyy",
                Value = DateTime.Now,
                CalendarForeColor = blue,
                CalendarTitleForeColor = blue,
                DropDownAlign = LeftRightAlignment.Left
            };

            // Currency Label, Colon, TextBox + Dropdown
            lblCurrency = new Label
            {
                Text = "Currency",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(labelX, startY + verticalGap + 5),
                Size = new Size(labelWidth, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };
            colonCurrency = new Label
            {
                Text = ":",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(colonX, startY + verticalGap + 5),
                Size = new Size(colonWidth, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Currency TextBox - DEFAULT CURRENCY SET
            txtCurrency = new TextBox
            {
                Font = new Font("Arial", 9, FontStyle.Regular),
                Size = new Size(currencyTextBoxWidth, 28), // Width kam (132px)
                Location = new Point(textBoxX, startY + verticalGap),
                BorderStyle = BorderStyle.FixedSingle,
                ReadOnly = true,
                Text = "PKR - 1.00" // DEFAULT CURRENCY SET HERE
            };

            // Currency Dropdown Button - Customer dropdown jaisi LIGHT OUTLINE
            btnCurrencyDropdown = new Button
            {
                Text = "▼",
                Font = new Font("Arial", 9, FontStyle.Bold),
                Size = new Size(dropdownButtonWidth, txtCurrency.Height), // Same height as textbox (28px)
                Location = new Point(dropdownX, startY + verticalGap), // TextBox ke right side
                BackColor = Color.White,
                ForeColor = blue,
                FlatStyle = FlatStyle.Flat,
                TabStop = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Padding = new Padding(0)
            };
            btnCurrencyDropdown.FlatAppearance.BorderColor = blue;
            btnCurrencyDropdown.FlatAppearance.BorderSize = 1; // LIGHT OUTLINE - 1 instead of 2
            btnCurrencyDropdown.FlatAppearance.MouseOverBackColor = pink;
            btnCurrencyDropdown.MouseEnter += BtnCurrencyDropdown_MouseEnter;
            btnCurrencyDropdown.MouseLeave += BtnCurrencyDropdown_MouseLeave;
            btnCurrencyDropdown.Click += BtnCurrencyDropdown_Click;

            // Taxable Label, Colon, CheckBox
            lblTaxable = new Label
            {
                Text = "Taxable",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(labelX, startY + (verticalGap * 2) + 5),
                Size = new Size(labelWidth, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };
            colonTaxable = new Label
            {
                Text = ":",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(colonX, startY + (verticalGap * 2) + 5),
                Size = new Size(colonWidth, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            chkTaxable = new CheckBox
            {
                Font = new Font("Arial", 9, FontStyle.Regular),
                ForeColor = Color.Black,
                Size = new Size(20, 20),
                Location = new Point(textBoxX, startY + (verticalGap * 2) + 3),
                Checked = false,
                Text = ""
            };

            // Amount W/O GST Label, Colon, TextBox
            lblAmountWOGST = new Label
            {
                Text = "Amt w/o GST",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(labelX, startY + (verticalGap * 3) + 5),
                Size = new Size(labelWidth, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };
            colonAmountWOGST = new Label
            {
                Text = ":",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(colonX, startY + (verticalGap * 3) + 5),
                Size = new Size(colonWidth, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            txtAmountWOGST = new TextBox
            {
                Font = new Font("Arial", 9, FontStyle.Regular),
                Size = new Size(160, 28),
                Location = new Point(textBoxX, startY + (verticalGap * 3)),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Amt GST Label, Colon, TextBox
            lblGST = new Label
            {
                Text = "Amt GST",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(labelX, startY + (verticalGap * 4) + 5),
                Size = new Size(labelWidth, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };
            colonGST = new Label
            {
                Text = ":",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(colonX, startY + (verticalGap * 4) + 5),
                Size = new Size(colonWidth, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            txtGST = new TextBox
            {
                Font = new Font("Arial", 9, FontStyle.Regular),
                Size = new Size(160, 28),
                Location = new Point(textBoxX, startY + (verticalGap * 4)),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Amount W/ GST Label, Colon, TextBox
            lblAmountWithGST = new Label
            {
                Text = "Amt w/ GST",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(labelX, startY + (verticalGap * 5) + 5),
                Size = new Size(labelWidth, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };
            colonAmountWithGST = new Label
            {
                Text = ":",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(colonX, startY + (verticalGap * 5) + 5),
                Size = new Size(colonWidth, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            txtAmountWithGST = new TextBox
            {
                Font = new Font("Arial", 9, FontStyle.Regular),
                Size = new Size(160, 28),
                Location = new Point(textBoxX, startY + (verticalGap * 5)),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Discount Label, Colon, TextBox + Dropdown
            lblDiscount = new Label
            {
                Text = "Discount",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(labelX, startY + (verticalGap * 6) + 5),
                Size = new Size(labelWidth, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Label colonDiscount = new Label
            {
                Text = ":",
                Font = rightSideLabelFont,
                ForeColor = blue,
                Location = new Point(colonX, startY + (verticalGap * 6) + 5),
                Size = new Size(colonWidth, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Discount TextBox - Currency jaisi width (132px)
            txtDiscount = new TextBox
            {
                Font = new Font("Arial", 9, FontStyle.Regular),
                Size = new Size(currencyTextBoxWidth, 28), // Same width as currency (132px)
                Location = new Point(textBoxX, startY + (verticalGap * 6)),
                BorderStyle = BorderStyle.FixedSingle,
                ReadOnly = true,
                Text = "Select Discount"
            };

            // Discount Dropdown Button - Currency button jaisi exact styling
            btnDiscountDropdown = new Button
            {
                Text = "▼",
                Font = new Font("Arial", 9, FontStyle.Bold),
                Size = new Size(dropdownButtonWidth, txtDiscount.Height), // Same size (28px)
                Location = new Point(dropdownX, startY + (verticalGap * 6)), // TextBox ke right side
                BackColor = Color.White,
                ForeColor = blue,
                FlatStyle = FlatStyle.Flat,
                TabStop = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Padding = new Padding(0)
            };
            btnDiscountDropdown.FlatAppearance.BorderColor = blue;
            btnDiscountDropdown.FlatAppearance.BorderSize = 1; // Light outline jaisi currency button
            btnDiscountDropdown.FlatAppearance.MouseOverBackColor = pink;
            btnDiscountDropdown.MouseEnter += BtnDiscountDropdown_MouseEnter;
            btnDiscountDropdown.MouseLeave += BtnDiscountDropdown_MouseLeave;
            btnDiscountDropdown.Click += BtnDiscountDropdown_Click;

            // Add all controls to right panel
            rightFieldsPanel.Controls.Add(lblDate);
            rightFieldsPanel.Controls.Add(colonDate);
            rightFieldsPanel.Controls.Add(dateTimePicker);

            rightFieldsPanel.Controls.Add(lblCurrency);
            rightFieldsPanel.Controls.Add(colonCurrency);
            rightFieldsPanel.Controls.Add(txtCurrency);
            rightFieldsPanel.Controls.Add(btnCurrencyDropdown); // Dropdown button add

            rightFieldsPanel.Controls.Add(lblTaxable);
            rightFieldsPanel.Controls.Add(colonTaxable);
            rightFieldsPanel.Controls.Add(chkTaxable);

            rightFieldsPanel.Controls.Add(lblAmountWOGST);
            rightFieldsPanel.Controls.Add(colonAmountWOGST);
            rightFieldsPanel.Controls.Add(txtAmountWOGST);

            rightFieldsPanel.Controls.Add(lblGST);
            rightFieldsPanel.Controls.Add(colonGST);
            rightFieldsPanel.Controls.Add(txtGST);

            rightFieldsPanel.Controls.Add(lblAmountWithGST);
            rightFieldsPanel.Controls.Add(colonAmountWithGST);
            rightFieldsPanel.Controls.Add(txtAmountWithGST);

            rightFieldsPanel.Controls.Add(lblDiscount);
            rightFieldsPanel.Controls.Add(colonDiscount);
            rightFieldsPanel.Controls.Add(txtDiscount);
            rightFieldsPanel.Controls.Add(btnDiscountDropdown);

            this.Controls.Add(rightFieldsPanel);
        }

        // ==========================================
        // SECTION 8: FORM LOAD AND RESIZE EVENTS (PROPER BOUNDS CHECKING)
        // ==========================================
        private void QuotationForm_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                SetFormBoundsToMainPanel();
            }
            PositionControls();
        }

        private void QuotationForm_Shown(object sender, EventArgs e)
        {
            // Ensure form maintains proper size when shown
            if (this.MdiParent != null)
            {
                SetFormBoundsToMainPanel();
            }
            PositionControls();
        }

        private void QuotationForm_Resize(object sender, EventArgs e)
        {
            if (isFormInitialized)
            {
                PositionControls();
            }
        }

        // PROPER 10PX GAP WITH BOUNDS CHECKING
        private void SetFormBoundsToMainPanel()
        {
            if (this.MdiParent == null) return;

            var mainPanel = this.MdiParent.Controls.OfType<Panel>().FirstOrDefault(p => p.Dock == DockStyle.Fill);

            if (mainPanel != null)
            {
                int gap = 10; // Gap reduced to 10 pixels

                // Calculate available space
                int availableWidth = mainPanel.ClientSize.Width - (gap * 2);
                int availableHeight = mainPanel.ClientSize.Height - (gap * 2);

                // Ensure minimum size
                int formWidth = Math.Max(Math.Min(originalFormSize.Width, availableWidth), this.MinimumSize.Width);
                int formHeight = Math.Max(Math.Min(originalFormSize.Height, availableHeight), this.MinimumSize.Height);

                // Set position with gap
                this.Location = new Point(gap, gap);
                this.Size = new Size(formWidth, formHeight);
            }
        }

        private void PositionControls()
        {
            if (!isFormInitialized) return;

            int buttonY = (pinkHeaderPanel.Height - 32) / 2;
            btnSelectQuotation.Left = this.ClientSize.Width - btnSelectQuotation.Width - 20;
            btnQuotationNo.Left = btnSelectQuotation.Left - btnQuotationNo.Width - 16;
            lblQuotationNo.Left = btnQuotationNo.Left - lblQuotationNo.Width - 4;
            btnSelectQuotation.Top = buttonY;
            btnQuotationNo.Top = buttonY;
            lblQuotationNo.Top = buttonY + 8;
            lblQuotationTitle.Left = btnSavePreview.Left;
            lblQuotationTitle.Top = (blueHeaderPanel.Height - lblQuotationTitle.Height) / 2;
            btnPreparedBy.Left = btnRefresh.Left + btnRefresh.Width;
            btnInitialBox.Left = btnPreparedBy.Left + btnPreparedBy.Width + 5;
            btnEditedBy.Left = btnInitialBox.Left + btnInitialBox.Width + 10;
            btnNewInitialBox.Left = btnEditedBy.Left + btnEditedBy.Width + 5;
            btnCopy.Left = btnNewInitialBox.Left + btnNewInitialBox.Width + 18;
            btnPreparedBy.Top = (blueHeaderPanel.Height - btnPreparedBy.Height) / 2;
            btnInitialBox.Top = (blueHeaderPanel.Height - btnInitialBox.Height) / 2;
            btnEditedBy.Top = (blueHeaderPanel.Height - btnEditedBy.Height) / 2;
            btnNewInitialBox.Top = (blueHeaderPanel.Height - btnNewInitialBox.Height) / 2;
            btnCopy.Top = (blueHeaderPanel.Height - btnCopy.Height) / 2;

            if (rightFieldsPanel != null)
            {
                // Simple positioning like your old code but with proper bounds
                rightFieldsPanel.Left = btnSelectQuotation.Left - 160;
                rightFieldsPanel.Top = pinkHeaderPanel.Height + blueHeaderPanel.Height + 15;

                // Ensure it doesn't go out of bounds
                if (rightFieldsPanel.Right > this.ClientSize.Width - 30)
                {
                    rightFieldsPanel.Left = this.ClientSize.Width - rightFieldsPanel.Width - 30;
                }

                if (rightFieldsPanel.Left < 750)
                {
                    rightFieldsPanel.Left = 750;
                }
            }

            if (leftFieldsPanel != null)
            {
                // Adjust left panel width if needed
                if (rightFieldsPanel != null && leftFieldsPanel.Right > rightFieldsPanel.Left - 20)
                {
                    leftFieldsPanel.Width = rightFieldsPanel.Left - leftFieldsPanel.Left - 20;
                }
            }
        }

        // ==========================================
        // SECTION 9: DEFAULT CURRENCY SETUP
        // ==========================================

        private void SetDefaultCurrency()
        {
            if (txtCurrency != null)
            {
                txtCurrency.Text = "PKR - 1.00";
            }
        }

        // ==========================================
        // SECTION 10: SAVE/EDIT/REFRESH BUTTON HOVER EVENTS
        // ==========================================

        private void BtnSavePreview_MouseEnter(object sender, EventArgs e)
        {
            Color pink = ColorTranslator.FromHtml("#f8bbd0");
            btnSavePreview.BackColor = pink;
            btnSavePreview.ForeColor = Color.White;
        }

        private void BtnSavePreview_MouseLeave(object sender, EventArgs e)
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnSavePreview.BackColor = Color.White;
            btnSavePreview.ForeColor = blue;
        }

        private void BtnEditPreview_MouseEnter(object sender, EventArgs e)
        {
            Color pink = ColorTranslator.FromHtml("#f8bbd0");
            btnEditPreview.BackColor = pink;
            btnEditPreview.ForeColor = Color.White;
        }

        private void BtnEditPreview_MouseLeave(object sender, EventArgs e)
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnEditPreview.BackColor = Color.White;
            btnEditPreview.ForeColor = blue;
        }

        private void BtnRefresh_MouseEnter(object sender, EventArgs e)
        {
            Color pink = ColorTranslator.FromHtml("#f8bbd0");
            btnRefresh.BackColor = pink;
            btnRefresh.ForeColor = Color.White;
        }

        private void BtnRefresh_MouseLeave(object sender, EventArgs e)
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnRefresh.BackColor = Color.White;
            btnRefresh.ForeColor = blue;
        }

        // ==========================================
        // SECTION 11: SELECT QUOTATION BUTTON EVENTS
        // ==========================================

        private void BtnSelectQuotation_MouseEnter(object sender, EventArgs e)
        {
            Color pink = ColorTranslator.FromHtml("#f8bbd0");
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnSelectQuotation.BackColor = pink;
            btnSelectQuotation.ForeColor = Color.White;
            btnSelectQuotation.FlatAppearance.BorderColor = blue;
            btnSelectQuotation.FlatAppearance.BorderSize = 2;
        }

        private void BtnSelectQuotation_MouseLeave(object sender, EventArgs e)
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnSelectQuotation.BackColor = Color.White;
            btnSelectQuotation.ForeColor = blue;
            btnSelectQuotation.FlatAppearance.BorderColor = blue;
            btnSelectQuotation.FlatAppearance.BorderSize = 2;
        }

        private void BtnSelectQuotation_Click(object sender, EventArgs e)
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnSelectQuotation.FlatAppearance.BorderColor = blue;
            btnSelectQuotation.FlatAppearance.BorderSize = 2;
            MessageBox.Show("Dropdown for Quotation selection open hoga yahan!", "Select Quotation");
        }

        // ==========================================
        // SECTION 12: PREPARED BY AND EDITED BY BUTTON EVENTS
        // ==========================================

        private void BtnPreparedBy_MouseEnter(object sender, EventArgs e)
        {
            btnPreparedBy.BackColor = ColorTranslator.FromHtml("#0d47a1");
            btnPreparedBy.ForeColor = Color.White;
        }

        private void BtnPreparedBy_MouseLeave(object sender, EventArgs e)
        {
            btnPreparedBy.BackColor = Color.White;
            btnPreparedBy.ForeColor = ColorTranslator.FromHtml("#0d47a1");
        }

        private void BtnPreparedBy_Click(object sender, EventArgs e)
        {
            try
            {
                // Open QuotationPreparedBy form
                QuotationPreparedBy preparedByForm = new QuotationPreparedBy();
                preparedByForm.ShowDialog();

                // Check if an employee was selected
                if (preparedByForm.DialogResult == DialogResult.OK)
                {
                    // Get selected employee data from your existing form
                    string employeeName = preparedByForm.SelectedName;
                    string employeeInitials = preparedByForm.SelectedInitials;

                    // Update Initial Box with initials + date
                    string currentDate = DateTime.Now.ToString("dd-MM-yy");
                    string initialWithDate = $"{employeeInitials} {currentDate}";

                    // Find and update the TextBox inside btnInitialBox Panel
                    TextBox txtInitialBox = btnInitialBox.Controls.OfType<TextBox>().FirstOrDefault();
                    if (txtInitialBox != null)
                    {
                        txtInitialBox.Text = initialWithDate;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Prepared By form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditedBy_MouseEnter(object sender, EventArgs e)
        {
            btnEditedBy.BackColor = ColorTranslator.FromHtml("#0d47a1");
            btnEditedBy.ForeColor = Color.White;
        }

        private void BtnEditedBy_MouseLeave(object sender, EventArgs e)
        {
            btnEditedBy.BackColor = Color.White;
            btnEditedBy.ForeColor = ColorTranslator.FromHtml("#0d47a1");
        }

        private void BtnEditedBy_Click(object sender, EventArgs e)
        {
            try
            {
                // Open QuotationPreparedBy form
                QuotationPreparedBy editedByForm = new QuotationPreparedBy();
                editedByForm.ShowDialog();

                // Check if an employee was selected
                if (editedByForm.DialogResult == DialogResult.OK)
                {
                    // Get selected employee data from your existing form
                    string employeeName = editedByForm.SelectedName;
                    string employeeInitials = editedByForm.SelectedInitials;

                    // Update New Initial Box with initials + date
                    string currentDate = DateTime.Now.ToString("dd-MM-yy");
                    string initialWithDate = $"{employeeInitials} {currentDate}";

                    // Find and update the TextBox inside btnNewInitialBox Panel
                    TextBox txtNewInitialBox = btnNewInitialBox.Controls.OfType<TextBox>().FirstOrDefault();
                    if (txtNewInitialBox != null)
                    {
                        txtNewInitialBox.Text = initialWithDate;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Edited By form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // SECTION 13: NEW INITIAL BOX BUTTON EVENTS
        // ==========================================

        private void BtnNewInitialBox_MouseEnter(object sender, EventArgs e)
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnNewInitialBox.BackColor = blue;
            btnNewInitialBox.ForeColor = Color.White;
        }

        private void BtnNewInitialBox_MouseLeave(object sender, EventArgs e)
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnNewInitialBox.BackColor = Color.White;
            btnNewInitialBox.ForeColor = blue;
        }

        // ==========================================
        // SECTION 14: CURRENCY DROPDOWN EVENT HANDLERS (LIGHT OUTLINE)
        // ==========================================

        private void BtnCurrencyDropdown_MouseEnter(object sender, EventArgs e)
        {
            Color pink = ColorTranslator.FromHtml("#f8bbd0");
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnCurrencyDropdown.BackColor = pink;
            btnCurrencyDropdown.ForeColor = Color.White;
            btnCurrencyDropdown.FlatAppearance.BorderSize = 1; // Light border on hover
        }

        private void BtnCurrencyDropdown_MouseLeave(object sender, EventArgs e)
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnCurrencyDropdown.BackColor = Color.White;
            btnCurrencyDropdown.ForeColor = blue;
            btnCurrencyDropdown.FlatAppearance.BorderSize = 1; // Light border normal state
        }

        private void BtnCurrencyDropdown_Click(object sender, EventArgs e)
        {
            // Click effect - light border maintain karo
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnCurrencyDropdown.FlatAppearance.BorderSize = 1; // Light border on click

            try
            {
                // Create and show your existing currency form
                CurrencyForm currencyForm = new CurrencyForm();

                // Show the form and check result
                if (currencyForm.ShowDialog() == DialogResult.OK)
                {
                    // Get selected currency from your existing form
                    string selectedCurrency = currencyForm.SelectedCurrency;

                    if (!string.IsNullOrEmpty(selectedCurrency))
                    {
                        // Your form already returns perfect format: "US Dollar $ - Rate: 383 PKR"
                        // Just extract symbol and rate for display
                        string displayText = ExtractCurrencyDisplay(selectedCurrency);
                        txtCurrency.Text = displayText;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening currency form: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Helper method to extract symbol and rate from currency string
        private string ExtractCurrencyDisplay(string currencyString)
        {
            try
            {
                // Input: "US Dollar $ - Rate: 383 PKR"
                // Output: "$ - 383"

                if (string.IsNullOrEmpty(currencyString))
                    return "PKR - 1.00";

                // Split by " - Rate: "
                string[] parts = currencyString.Split(new string[] { " - Rate: " }, StringSplitOptions.None);

                if (parts.Length == 2)
                {
                    // Extract symbol from first part (last word before " - Rate:")
                    string[] leftParts = parts[0].Trim().Split(' ');
                    string symbol = leftParts[leftParts.Length - 1]; // Last word is symbol

                    // Extract rate from second part (remove " PKR")
                    string rate = parts[1].Replace(" PKR", "").Trim();

                    return $"{symbol} - {rate}";
                }
                else
                {
                    // Fallback - return as is
                    return currencyString;
                }
            }
            catch
            {
                // Fallback on any error
                return "PKR - 1.00";
            }
        }

        // ==========================================
        // SECTION 15: DISCOUNT DROPDOWN EVENT HANDLERS
        // ==========================================

        private void BtnDiscountDropdown_MouseEnter(object sender, EventArgs e)
        {
            Color pink = ColorTranslator.FromHtml("#f8bbd0");
            btnDiscountDropdown.BackColor = pink;
            btnDiscountDropdown.ForeColor = Color.White;
            btnDiscountDropdown.FlatAppearance.BorderSize = 1; // Light border on hover
        }

        private void BtnDiscountDropdown_MouseLeave(object sender, EventArgs e)
        {
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnDiscountDropdown.BackColor = Color.White;
            btnDiscountDropdown.ForeColor = blue;
            btnDiscountDropdown.FlatAppearance.BorderSize = 1; // Light border normal state
        }

        private void BtnDiscountDropdown_Click(object sender, EventArgs e)
        {
            // Click effect - light border maintain karo
            Color blue = ColorTranslator.FromHtml("#0d47a1");
            btnDiscountDropdown.FlatAppearance.BorderSize = 1; // Light border on click

            try
            {
                // Create and show discount selection form
                DiscountSelectionForm discountForm = new DiscountSelectionForm();

                // Show the form and check result
                if (discountForm.ShowDialog() == DialogResult.OK)
                {
                    // Get selected discount percentage
                    decimal selectedPercentage = discountForm.SelectedDiscountPercentage;

                    if (selectedPercentage >= 0)
                    {
                        // Display percentage in textbox
                        txtDiscount.Text = selectedPercentage + "%";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening discount form: {ex.Message}", "Kamal Pasha Fabrics",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // END OF SECTION 15
        // ==========================================
    }
}