function addLanguageRow() {

        @{
            Model.User.Languages.Add(new Data.Language());
        }

    var languageDropdown = $("#languageList");
    var index = $("#languagesBody").children("tr").length;

    var indexCell = "<td style='display:none'><input name='User.Languages.Index' type='hidden' value='" + index + "' /></td>";
    var titleCell = "<td><input id='Languages_" + index + "__Name' name='User.Languages[" + index + "].Name' type='text' value='"
        + languageDropdown.options[languageDropdown.selectedIndex].text + "' readonly/></td>";

    var removeCell = "<td><input id='btnRemoveLanguage' type='button' value='Remove' onclick='removeRow(" + index + ");' /></td>";

    var newRow = "<tr id='languagesRow" + index + "'>" + indexCell + titleCell + publishedCell + removeCell + "</tr>";
    $("#languagesBody").append(newRow);
}

function removeRow(id) {
    var controlToBeRemoved = "#languagesRow" + id;
    $(controlToBeRemoved).remove();
}

$("#btnAddLanguage").click(addLanguageRow());