﻿$(document).ready(function () {
    var selects = $('.filter-select').select2({
        ajax: {
            type: 'POST',
            url: '/Select2/GetFilteredResult',
            //url: '/Test/GetFilteredResult',
            processResults: function (data) {
                return {
                    results: $.map(data, function (item) {
                        return {
                            text: item.value,
                            id: item.key
                        }
                    })
                };
            },
            data: function (params) {
                var that = this;
                params.filters = JSON.parse(JSON.stringify(filters));
                var existingFilter = params.filters.find(function (filter) {
                    return filter.column === $(that).attr('column');
                });
                if (existingFilter) {
                    existingFilter.value = params.term;
                    existingFilter.editing = true;
                } else {
                    params.filters.push({ column: $(this).attr('column'), value: params.term, name: $(this).attr('key-name') ? $(this).attr('key-name') : $(this).attr('name'), editing: true, table: $(this).attr('table') });
                }
                return { filters: params.filters };
            },
            dataType: 'json'
        },
        allowClear: true,
        placeholder: 'Введите фильтр',
        minimumInputLength: 2,
        //delay: 1500,
        language: {
            inputTooShort: function (args) {
                var remainingChars = args.minimum - args.input.length;
                var message = 'Пожалуйста введите ' + remainingChars + ' или более символов';
                return message;
            },
            noResults: function () {
                return 'Ничего не найдено';
            },
            loadingMore: function () {
                return 'Подгружаем результаты...';
            },
            searching: function () {
                return 'Ищем в базе…';
            }
        }
    });
    var filters = [];
    selects.on('select2:select', function (e) {
        var that = this;
        var existingFilter = filters.find(function (filter) {
            return filter.column === $(that).attr('column');
        });

        if (existingFilter) {
            existingFilter.value = $(this).val();
        } else {
            filters.push({ column: $(this).attr('column'), value: $(this).val() });
            for (var i = filters.length - 1; i >= 0; --i) {
                if (filters[i].column == $(this).attr('column')) {
                    filters.splice(i, 1);
                }
            }
        }
    });
    selects.on('select2:unselect', function (e) {
        for (var i = filters.length - 1; i >= 0; --i) {
            if (filters[i].column == $(this).attr('column')) {
                filters.splice(i, 1);
            }
        }
    })
});
//$(function () {
//    $('.date-picker').datepicker({
//        changeMonth: true,
//        changeYear: true,
//        showButtonPanel: true,
//        beforeShow: function (input) {
//            setTimeout(function () {
//                var buttonPane = $(input)
//                    .datepicker("widget")
//                    .find(".ui-datepicker-buttonpane");

//                $("<button>", {
//                    text: "Clear",
//                    click: function () {
//                        $.datepicker._clearDate(input);
//                    }
//                }).appendTo(buttonPane).addClass("ui-datepicker-clear ui-state-default ui-priority-primary ui-corner-all");
//            }, 1);
//        },
//        onChangeMonthYear: function (year, month, instance) {
//            setTimeout(function () {
//                var buttonPane = $(instance)
//                    .datepicker("widget")
//                    .find(".ui-datepicker-buttonpane");

//                $("<button>", {
//                    text: "Очистить",
//                    click: function () {
//                        $.datepicker._clearDate(instance.input);
//                    }
//                }).appendTo(buttonPane).addClass("ui-datepicker-clear ui-state-default ui-priority-primary ui-corner-all");
//            }, 1);
//        },
//        dateFormat: 'MM yy',
//        onClose: function (dateText, inst) {
//            $(this).datepicker('setDate', new Date(inst.selectedYear, inst.selectedMonth, 1));
//        }
//    });
//    $.datepicker.regional['rus'] = {
//        currentText: "Сегодня", 
//        monthNames: ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"],
//        monthNamesShort: ["Янв", "Фев", "Мар", "Апр", "Май", "Июн", "Июл", "Авг", "Сен", "Окт", "Ноя", "Дек"],
//    };
//    $.datepicker.setDefaults($.datepicker.regional['rus']);
//});