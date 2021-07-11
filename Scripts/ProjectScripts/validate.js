$('#btncreate').click(function (e) {
    debugger;

    $('.form-control').each(function (i, v) {
        if ($(v).val().trim() == null || $(v).val().trim() == '' || ($(v).attr('type') == 'number' && $(v).val() == '0')) {
            e.preventDefault();
            $(v).addClass('danger');
            $(v).next('.text-danger').text('value cannot be empty.');
            debugger;
            if ($(v).attr('type') == 'number' && $(v).val() == '0')
                $(v).next('.text-danger').text('value cannot be 0');
        }
        else {
            $(v).removeClass('danger');
            $(v).next('.text-danger').text('');
        }
    });

})