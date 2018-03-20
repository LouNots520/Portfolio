// Main JavaScript file

$(document).ready(function () {

    $("#startDate").datepicker();
    $("#endDate").datepicker();
    //$("#datepicker3").datepicker();
    //$("#datepicker4").datepicker();

    $("select1").imagepicker();
    //End Calendar js

    //Sidebar JavaScript
    $("#showLeft").click(function (e) {
        e.preventDefault();
        $("#pageWrapper").toggleClass("toggled");

        //code for left sidebar button to change
        var isRightArrows = $('#showLeft i').hasClass('fa-angle-double-right');
        if (isRightArrows) {
            $('#showLeft i').removeClass('fa-angle-double-right');
            $('#showLeft i').addClass('fa-angle-double-left');
        } else {
            $('#showLeft i').removeClass('fa-angle-double-left');
            $('#showLeft i').addClass('fa-angle-double-right');
        }
    });

    //Top toolbar button JavaScript for icon flipping up/down only
    $("#showTop").click(function (e) {
        e.preventDefault();
        $("#collapse").toggleClass("toggled");

        var isDownArrows = $('#showTop i').hasClass('fa-angle-double-down');
        if (isDownArrows) {
            $('#showTop i').removeClass('fa-angle-double-down');
            $('#showTop i').addClass('fa-angle-double-up');
        } else {
            $('#showTop i').removeClass('fa-angle-double-up');
            $('#showTop i').addClass('fa-angle-double-down');
        }
    });

    //Click Dashboard Tab to show its content

    $("#dashTabContainer").on("click", "a", function (e) {
        e.preventDefault();
        $(this).tab('show');
    });

    // ---------------------- Louis Graph Form Code ----------------------

    //Function for changing visibility of html item
    (function ($) {
        $.fn.invisible = function () {
            return this.each(function () {
                $(this).css("visibility", "hidden");
            });
        };
        $.fn.visible = function () {
            return this.each(function () {
                $(this).css("visibility", "visible");
            });
        };
    }(jQuery));

    //To Reset Form To Default
    $('#DashID').hide();
    $('input:radio[name=gType]:checked').prop('checked', false);
    $("#timeInt").prop('disabled', false);
    $('#timeInt').val('0');
    $('#amount').val('1');
    $("#sField").prop('disabled', false);
    $('#sField option').eq(0).prop('selected', true);
    $('#of').visible();
    $('#sField').visible();
    $('#cField option').eq(0).prop('selected', true);
    $('#ofSubLists li').each(function (index) {
        if (index == 0) {
            $(this).show();
            $(this).find('option').val('NONE');
        }
        else {
            $(this).hide();
            $(this).find('option').val('NONE');
        }
    });
    $('#groupby').text("Group by: (x-axis)");
    $('#gbField option').eq(0).prop('selected', true);
    $('#gbSubLists li').each(function (index) {
        if (index == 0) {
            $(this).show();
            $(this).find('option').val('NONE');
        }
        else {
            $(this).hide();
            $(this).find('option').val('NONE');
        }
    });
    $("input[name=range][value='0']").prop("checked", true);
    $("input[name=range][value='1']").prop("checked", false);
    $("#startDate").prop('disabled', true);
    $("#endDate").prop('disabled', true);
    $("#startDate").prop('value', "");
    $("#endDate").prop('value', "");

    //To Set Current Dashboard to g.GraphID value on Page Load
    $('#DashID').attr('value', $(".dTabs .active a").text());

    //To Get Current Dashboard
    $("#dashTabContainer").on("click", "a", function (e) {
        e.preventDefault();
        $(this).tab('show');
        $('#DashID').attr('value', '----'.replace("----", $(this).text()));
    });

    //To Disable "To:" and "From:" Fields when "None" Radio Button Checked
    $('input:radio[name=range]').change(function () {
        if (this.value == '1') {
            //Enabling the Text Boxes
            $("#startDate").prop('disabled', false);
            $("#endDate").prop('disabled', false);
        }
        else {
            //Disabling and Clearing the Text Boxes
            $("#startDate").prop('disabled', true);
            $("#endDate").prop('disabled', true);
            $("#startDate").prop('value', "");
            $("#endDate").prop('value', "");
        }
    });

    //To Disable Field Drop Down List Based on "Amount:" Value
    $('#amount').change(function () {
        //For "Count" Selection
        if (this.value == '2') {
            $("#sField").prop('disabled', true);
            $('#of').invisible();
            $('#sField').invisible();
        }
            //For "Sum" Selection
        else {
            $("#sField").prop('disabled', false);
            $('#of').visible();
            $('#sField').visible();
        }
    });

    //To Disable "Time Interval:" Drop Down List based on Graph Selection
    //To Change "Group By: (x-axis)" to "Group By: (y-axis)" based on Graph Selection
    $('input:radio[name=gType]').change(function () {
        if (this.value == '6') {
            //Disable "Time Interval:" Drop Down List and Set Value to "None"
            $("#timeInt").prop('disabled', true);
            $('#timeInt').val('0');
            $('#groupby').text("Group by: (x-axis)");
        }
        else if (this.value == '5') {
            $('#groupby').text("Group by: (y-axis)");
        }
        else {
            $("#timeInt").prop('disabled', false);
            $('#groupby').text("Group by: (x-axis)");
        }
    });
    //To Show and Hide Proper "of:" or "for" Sub Drop Down List 
    $("#cField").change(function () {
        var keep = $("select[name='cField'] option:selected").index();
        $('#ofSubLists li').each(function (index) {
            if (index == keep) {
                $(this).show();
            }
            else {
                $(this).hide();
            }
        });
    });

    //To Show and Hide Proper "Group By:" Sub Drop Down List 
    $("#gbField").change(function () {
        var keep = $("select[name='gbField'] option:selected").index();
        $('#gbSubLists li').each(function (index) {
            if (index == keep) {
                $(this).show();
            }
            else {
                $(this).hide();
            }
        });
    });

    //---------- Top Bar Button Functions ----------

    //Delete Button Function
    //For Page Load
    $('.toDelete').attr('onclick', 'location.href="/Graph/DeleteDash?dashboardname=----"'.replace("----", $(".dTabs .active a").text()));
    //For Dashboard Change
    $('#dashTabContainer').click( function () {
        $('.toDelete').attr('onclick', 'location.href="/Graph/DeleteDash?dashboardname=----"'.replace("----", $(".dTabs .active a").text()));
    });

    //Print Button Function
    $('#printbtn').click(function () {
        //Opens new window with graph for printing.
        var divContents = $('#workspaceContent').html();
        var printWindow = window.open('', '', 'height=400,width=800');
        printWindow.document.write(divContents);
        printWindow.document.close();
        printWindow.print();
        printWindow.close();
    });

    //Tutorial window
   
        $("#helpbtn").click(function () {
            $("#myModal").modal();
        });
 
});//closing braces for whole document