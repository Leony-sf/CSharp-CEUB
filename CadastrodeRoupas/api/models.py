from typing import List
from datetime import datetime

class Roupa:
    def __init__(self, id: int, nome: str, preco: float, tamanho: str, usuario: str, data_hora: datetime):
        self.id = id
        self.nome = nome
        self.preco = preco
        self.tamanho = tamanho
        self.usuario = usuario
        self.data_hora = data_hora

# Lista de roupas no começo do sistema para simular um "banco de dados"
# Essa lista será modificada pelas operações CRUD
# Vale ressaltar que é apenas uma lista de simulação visual.
roupas: List[Roupa] = [
    Roupa(1, "Camiseta", 49.90, "M", "admin", datetime.now()),
    Roupa(2, "Calça Jeans", 129.90, "42", "admin", datetime.now()),
]
