function openDangerModal(data) {
    $('#modalError .modal-body .alert').html(data);
    var myModal = new bootstrap.Modal(document.getElementById('modalError'));
    myModal.show();

}

function openDefaultDangerModal() {
    openDangerModal('Something went wrong');
}


function openSuccessModal(data) {
    $('#modalSuccess .modal-body .alert').html(data);
    var myModal = new bootstrap.Modal(document.getElementById('modalSuccess'));
    myModal.show();
}
