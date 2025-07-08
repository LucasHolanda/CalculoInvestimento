# Build stage
FROM node:20-alpine AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# Debug: listar arquivos gerados
RUN echo "Conteúdo de /app/dist:" && ls -l /app/dist && echo "Conteúdo de /app/dist/calculo-investimento-front-end:" && ls -l /app/dist/calculo-investimento-front-end

# Production stage
FROM nginx:alpine
COPY --from=build /app/dist/calculo-investimento-front-end /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]