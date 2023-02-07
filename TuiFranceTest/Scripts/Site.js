function openModalWithAjaxContent(modal, contentUrl, onSuccessContent) {
    var modalContent = modal.find('.modal-body'),
        modalButtons = modal.find('.modal-footer .btn:not([data-dismiss])');
    modalButtons.attr('disabled', true);
    if (modalContent && contentUrl) {
        modal.one('show.bs.modal', function () {
            $.ajax({
                url: contentUrl,
                type: 'GET',
                cache: false,
                success: function (result) {
                    modalContent.html(result);
                    modalButtons.attr('disabled', false);
                    if (onSuccessContent) { onSuccessContent(modal, modalContent); }
                },
                error: function (request, status, error) {
                    alert('Error : ' + request.responseText);
                }
            });
        });
        modal.modal('show');
    }
};