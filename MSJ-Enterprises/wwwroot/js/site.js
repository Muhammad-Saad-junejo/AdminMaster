


function calculateAmount(elem) {
    let row = elem.closest('tr');
    let qty = parseFloat(row.querySelector('.qty').value) || 0;
    let rate = parseFloat(row.querySelector('.rate').value) || 0;
    let discount = parseFloat(row.querySelector('.discount').value) || 0;
    let amount = row.querySelector('.amount');
    if (qty && rate) {
        let total = qty * rate;
        amount.textContent = (total - discount).toFixed(2);
    } else {
        amount.textContent = '0.00';
    }
    calculateTotal();
}

document.addEventListener('DOMContentLoaded', function () {
    calculateAmounts();
    calculateTotals();
});

function calculateAmounts() {
    var table = document.getElementById('saleTable');
    var rows = table.getElementsByTagName('tr');

    for (var i = 1; i < rows.length; i++) {
        var qty = parseFloat(rows[i].getElementsByClassName('iQty')[0].innerText) || 0;
        var rate = parseFloat(rows[i].getElementsByClassName('iRate')[0].innerText) || 0;
        var discount = parseFloat(rows[i].getElementsByClassName('iDiscount')[0].innerText) || 0;
        var amount = (qty * rate) - discount;

        rows[i].getElementsByClassName('iamount')[0].innerText = amount.toFixed(2);
    }
}






function calculateTotal() {
    let total = 0;
    document.querySelectorAll('.amount').forEach(amountCell => {
        total += parseFloat(amountCell.textContent) || 0;
    });
    document.querySelector('#totalAmount').textContent = total.toFixed(2);
}
function calculateTotal2() {
    let total = 0;

    document.querySelectorAll('.iamount').forEach(function (element) {
        // Debug: Log the inner text of each iamount element
        console.log('iamount value:', element.innerText);

        // Parse the value as a float and add it to the total
        let amount = parseFloat(element.innerText || element.textContent) || 0;

        // Debug: Log the parsed amount
        console.log('Parsed amount:', amount);

        total += amount;
    });

    // Update the Total field with the calculated sum
    document.querySelector('#invoiceTotal').innerText = total.toFixed(2); // Assuming two decimal places
}

window.onload = function () {
    calculateTotal2();
};



function addRow() {


    let table = document.querySelector('#myTable tbody');
    let newRow = document.createElement('tr');

    let rowCount = table.querySelectorAll('tr').length;

    newRow.innerHTML = `
            
       <td class="col-md-8">
            <div>
                <label for="SaleInvoiceItems_${rowCount}__ItemId" class="form-label"></label>
                <select name="SaleInvoiceItems[${rowCount}].ItemId" class="form-select" onchange="populateItems(this)">
                    
                    ${document.querySelector('#item').innerHTML}
                </select>
            </div>
        </td>
        <td class="col-md-1">
            <div>
                <label for="SaleInvoiceItems_${rowCount}__Quantity" class="form-label"></label>
                <input type="number" name="SaleInvoiceItems[${rowCount}].Quantity" oninput="calculateAmount(this)" class="form-control qty">
            </div>
        </td>
        <td class="col-md-1">
            <div>
                <label for="SaleInvoiceItems_${rowCount}__Rate" class="form-label"></label>
                <input type="number" name="SaleInvoiceItems[${rowCount}].Rate" oninput="calculateAmount(this)" class="form-control rate">
            </div>
        </td>
        <td class="col-md-1">
            <div>
                <label for="SaleInvoiceItems_${rowCount}__Discount" class="form-label"></label>
                <input type="number" name="SaleInvoiceItems[${rowCount}].Discount" class="form-control discount" oninput="calculateAmount(this)">
            </div>
        </td>
        <td class="col-md-1">
            <label for="SaleInvoiceItems_${rowCount}__Amount" class="form-label"></label>
            <h4 style="margin-top:8px" class="form-control amount">0.00</h4>
        </td>
        <td class="col-md-1">
            <div class="button-container">
                <button onclick="deleteRow(this)" type="button" id="delete" class="btn btn-danger form-control">-</button>
            </div>
        </td>
    `;

    table.appendChild(newRow);
}


function deleteRow(button) {
    let row = button.closest('tr');
    row.parentNode.removeChild(row);
    calculateTotal();

}




// bank Detail Js


// Function to calculate totals and remaining balance
function calculateTotals() {
    let totalDebit = 0;
    let totalCredit = 0;

    // Calculate total debit
    document.querySelectorAll('.debit').forEach(function (debitCell) {
        totalDebit += parseFloat(debitCell.textContent);
    });

    // Calculate total credit
    document.querySelectorAll('.credit').forEach(function (creditCell) {
        totalCredit += parseFloat(creditCell.textContent);
    });

    // Display total debit and credit
    document.querySelector('.Dtotal').textContent = totalDebit;
    document.querySelector('.Ctotal').textContent = totalCredit;

    // Calculate and display remaining balance
    let remainingBalance = totalDebit - totalCredit;
    document.querySelector('.Total').textContent = remainingBalance;
}

// Call the function to calculate totals and remaining balance
calculateTotals();



function printA4() {
    window.print();
}




