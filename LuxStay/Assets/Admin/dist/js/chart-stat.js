$(function () {
    var ctx = $("#lineChart");
    var chart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: [],//['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6', 'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10'],
            datasets: [
                {
                    label: 'Doanh thu',
                    backgroundColor: 'rgba(34,177,76,1)',
                    borderColor: 'rgba(34,177,76,0.6)',
                    fill: false,
                    //pointRadius: false,
                    //pointColor: '#3b8bba',
                    //pointStrokeColor: 'rgba(60,141,188,1)',
                    //pointHighlightFill: '#fff',
                    //pointHighlightStroke: 'rgba(60,141,188,1)',
                    //data: [44, 83, 18, 100, 30, 83, 10, 92, 96, 52]
                },
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            datasetFill: false,
            scales: {
                yAxes: [{
                    ticks: {
                        precision: 0
                    }
                }]
            }
        }
    })

    $.ajax({
        url: "/Admin/Stat/Value",
        method: "post",
        data: { length: 10 },
        dataType: "json",
        success: function (data) {
            console.log(data);
            var labels = data.map(function (e) {
                return e.labels;
            });
            var values = data.map(function (e) {
                return e.values;
            });

            chart.data.labels = labels;
            chart.data.datasets[0].data = values;
            chart.update();
        }
    });
    
})