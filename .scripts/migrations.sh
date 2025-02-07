#!/bin/bash

# Espera o banco de dados estar pronto
echo "Esperando o banco de dados iniciar..."
until (echo > /dev/tcp/auth-db/3306) &>/dev/null; do
  echo "Aguardando banco de dados..."
  sleep 1
done

# Rodando as migrações
dotnet ef database update --project R"&"RSolucoesFinanceiraAuth.WebApi

# Rodando o aplicativo
exec dotnet R"&"RSolucoesFinanceiraAuth.WebApi.dll