/* Code for Logout Popup */

$(document).ready(function () {

    function deselect(e) {
        $('.logoutpop').slideFadeToggle(function () {
            e.removeClass('selected');
        });
    }

    $(function () {
        $('#logout').on('click', function () {
            if ($(this).hasClass('selected')) {
                deselect($(this));
            } else {
                $(this).addClass('selected');
                $('.logoutpop').slideFadeToggle();
            }
            return false;
        });

        $('#No').on('click', function () {
            deselect($('#contact'));
            return false;
        });
    });

    $.fn.slideFadeToggle = function (easing, callback) {
        return this.animate({ opacity: 'toggle', height: 'toggle' }, 'fast', easing, callback);
    };
});