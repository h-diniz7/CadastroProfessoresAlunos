function removerAluno(Id) {
    if (confirm("Tem certeza que deseja excluir este aluno?")) {
        fetch('/Alunos/Deletar?Id=' + Id, { method: 'DELETE' })
            .then(res => {
                if (res.ok) {
                    document.getElementById('aluno-' + Id).remove();
                } else {
                    alert('Erro ao excluir aluno');
                }
            });
    }
}