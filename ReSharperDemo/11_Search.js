  function UpdateValidations() {
        initialValue = $("#" + "<%= InitialNarrative.ClientID %>").val();
        var cbo = $find("<%=cboVariablePrefix.ClientID %>");
        var narMax = $get('<%= txtFreeNarrative.ClientID %>').maxLength;
        if (cbo) {
            var item = cbo.get_selectedItem();
            if (item) {
                var itemText = item.get_text();
                var txtMax = $get("hdnPrefixMax");
                var maxlength;
                if (itemText.length > narMax) {
                    if (initialValue == "Prefix") {
                        maxLength = 0;
                        var variableValidator = $get('<%= variableValidator.ClientID %>');
                        ValidatorEnable(variableValidator, false);
                        $('#LabelNarrativeWarning').css("visibility", "visible");
                        Disable();
                    }
                } else {
                    if (initialValue == "Prefix") {
                        var variableValidator = $get('<%= variableValidator.ClientID %>');
                        ValidatorEnable(variableValidator, true);
                        maxlength = txtMax.value - itemText.length;
                        $('#LabelNarrativeWarning').css("visibility", "hidden");
                        Enable();
                    }
                }
            }
        }
        var txt = $find("<%= txtVariablePrefix.ClientID %>");
        if (txt) {
            txt.set_maxLength(maxlength);
            txt.set_value("");
        }
    }

    function Disable() {
        var objState = $find("<%= txtVariablePrefix.ClientID %>");
        objState.disable();
    }

    function Enable() {
        var objState = $find("<%= txtVariablePrefix.ClientID %>");
        objState.enable();
    }

    function UpdateNarratives() {

        $("#<%= prefix.ClientID %>").show();
        $("#<%= @fixed.ClientID %>").show();
        $("#<%= free.ClientID %>").show();
        $("#<%= autogen.ClientID %>").show();
        $("#<%= template.ClientID %>").show();
    }

    function showMessage() {
    alert('Testing');
}