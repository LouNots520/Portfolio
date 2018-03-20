/* Code for NewDash Popup */

$(document).ready(function () {

    function deselect(e) {
        $('.newdashpop').slideFadeToggle(function () {
            e.removeClass('selected');
        });
    }

    $(function () {
        $('#newDash').on('click', function () {
            if ($(this).hasClass('selected')) {
                deselect($(this));
            } else {
                $(this).addClass('selected');
                $('.newdashpop').slideFadeToggle();
            }
            return false;
        });

        $('#Cancel2').on('click', function () {
            $('#dashboardname').prop('value', "");
            deselect($('#contact'));
            return false;
        });
    });

    $.fn.slideFadeToggle = function (easing, callback) {
        return this.animate({ opacity: 'toggle', height: 'toggle' }, 'fast', easing, callback);
    };

    $('.dNameget').on('blur', function () {
        $('.dNameset').attr('onclick', 'location.href="/Graph/NewDash?dashboardname=----"'.replace("----", $('.dNameget').val()));
    });
});