var vanchi_format_services = {
    formatMoney: function (money) {
        if (money == null)
        {
            return '';
        }
        money = money.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
        return money;
    }
};