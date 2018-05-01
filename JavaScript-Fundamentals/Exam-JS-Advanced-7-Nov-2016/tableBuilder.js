function tableBuilder(selector) {
    let table = $('<table>');
    return {
        createTable: function(columnNames) {
            let tableRow = $('<tr>');
            for (let name of columnNames) {
                let tableHeader = ($('<th>').text(name));
                tableRow.append(tableHeader);
            }
            tableRow.append('<th>Action</th>');
            $(selector).empty();
            table.append(tableRow);
            $(selector).append(table);
        },
        fillData: function(dataRows) {
            for (let currentDataRow of dataRows) {
                let tableRow = $('<tr>');
                for (let cellData of currentDataRow) {
                    tableRow.append($('<td>').text(cellData))
                }
                let deleteButton = $('<td><button>Delete</button></td>').on('click', () => tableRow.remove());
                tableRow.append(deleteButton);
                table.append(tableRow);
            }
        }
    }
}