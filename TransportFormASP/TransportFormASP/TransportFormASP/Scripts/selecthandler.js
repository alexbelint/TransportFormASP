$(document).ready(function () {
    var selects = $('.filter-select').select2({
        ajax: {
            type: 'POST',
            url: '/RailTransportationRequests/GetFilteredResult',
            processResults: function (data) {
                return {
                    results: $.map(data, function (item) {
                        return {
                            text: item.value,
                            id: item.value
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
                    params.filters.push({ column: $(this).attr('column'), value: params.term, editing: true, table: $(this).attr('table') });
                }
                return { filters: params.filters };
            },
            dataType: 'json'
        },
        allowClear: true,
        placeholder: 'Введите фильтр',
        minimumInputLength: 3,
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
