CREATE TABLE IF NOT EXISTS customer (
    id_customer SERIAL PRIMARY KEY,
    name_customer VARCHAR(150) NOT NULL,
    customer_type VARCHAR(10) NOT NULL DEFAULT 'FISICA' CHECK (customer_type IN ('FISICA', 'JURIDICA')),
    document_cpf_cnpj VARCHAR(20) UNIQUE,
    state_registration_rg VARCHAR(30),
    phone VARCHAR(20),
    email VARCHAR(120),
    postal_code VARCHAR(10),
    address_street VARCHAR(150),
    address_number VARCHAR(20),
    address_neighborhood VARCHAR(100),
    address_city VARCHAR(100),
    address_state VARCHAR(2),
    address_complement VARCHAR(100),
    credit_limit NUMERIC(10, 2) NOT NULL DEFAULT 0.00,
    notes TEXT,
    active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMP WITH TIME ZONE DEFAULT TIMEZONE('utc'::text, NOW())
);

CREATE INDEX idx_customer_name ON customer (name_customer);
CREATE INDEX idx_customer_document ON customer (document_cpf_cnpj);
CREATE INDEX idx_customer_phone ON customer (phone);