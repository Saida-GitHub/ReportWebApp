window.exportTableToExcel = (tableId, filename) => {
    const table = document.getElementById(tableId);

    // Clone the table to avoid modifying the original DOM
    const clonedTable = table.cloneNode(true);

    // Remove the second row of <thead> (search inputs)
    const thead = clonedTable.querySelector('thead');
    if (thead && thead.rows.length > 1) {
        thead.deleteRow(1); // Removes the second row with inputs
    }

    const html = clonedTable.outerHTML;

    const uri = 'data:application/vnd.ms-excel;base64,';
    const template = `
        <html xmlns:o="urn:schemas-microsoft-com:office:office"
              xmlns:x="urn:schemas-microsoft-com:office:excel"
              xmlns="http://www.w3.org/TR/REC-html40">
        <head><!--[if gte mso 9]>
            <xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet>
            <x:Name>Sheet1</x:Name>
            <x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions>
            </x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml>
            <![endif]-->
        </head>
        <body><table>{table}</table></body>
        </html>`;

    const base64 = (s) => window.btoa(unescape(encodeURIComponent(s)));
    const format = (s, c) => s.replace(/{(\w+)}/g, (m, p) => c[p]);

    const ctx = { table: html };
    const link = document.createElement("a");
    link.download = filename || 'report.xls';
    link.href = uri + base64(format(template, ctx));
    link.click();
};
