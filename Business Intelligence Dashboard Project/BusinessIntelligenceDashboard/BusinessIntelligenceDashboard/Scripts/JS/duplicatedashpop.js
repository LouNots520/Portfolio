/* Code for Duplicate Popup */

$(document).ready(function () {

    function deselect(e) {
        $('.duplicatedashpop').slideFadeToggle(function () {
            e.removeClass('selected');
        });
    }

    $(function () {
        $('#duplicatebtn').on('click', function () {
            if ($(this).hasClass('selected')) {
                deselect($(this));
            } else {
                $(this).addClass('selected');
                $('.duplicatedashpop').slideFadeToggle();
            }
            return false;
        });

        $('#Cancel1').on('click', function () {
            $('#newname').prop('value', "");
            deselect($('#contact'));
            return false;
        });
    });

    $.fn.slideFadeToggle = function (easing, callback) {
        return this.animate({ opacity: 'toggle', height: 'toggle' }, 'fast', easing, callback);
    };

    $('.newDashName').on('blur', function () {
        $('.newNameset').attr('onclick', 'location.href="/Graph/Duplicate?dashboardname=----&newName=++++"'.replace("----", $(".dTabs .active a").text()).replace("++++", $('.newDashName').val()));
    });
});