//
//  RegisterationForm.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/5/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation
import UIKit

protocol registrationFormDelegate {
    func didPressSignup(form: RegistrationForm)
    func didPressAlreadyHaveAccount(form: RegistrationForm)
}

class RegistrationForm: UIView {
    ////////////////////////////////////
    //            Delegates
    ////////////////////////////////////
    var delegate: registrationFormDelegate?

    ////////////////////////////////////
    //            Gestures
    ////////////////////////////////////
    var alreadyHaveAccountTapped:UITapGestureRecognizer!
    
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    let logo: UIImageView = {
        let image = UIImageView()
        image.image = UIImage(named: "logo")
        image.contentMode = .scaleAspectFit
        image.layer.masksToBounds = true
        image.frame.size = CGSize(width: Helper.getWidthOf(xdWidth: 208, referenceWidth: nil, originalWidth: nil), height: Helper.getHeightOf(xdHeight: 84, referenceHeight: nil, originalHeight: nil))
        return image
    }()
    
    let emailField: TextField = {
        let field = TextField()
        field.backgroundColor = UIColor(hex: "#0D161F")
        field.attributedPlaceholder = NSAttributedString(string: "Email", attributes: [NSAttributedStringKey.foregroundColor: UIColor(hex: "#95989A") ?? UIColor.lightGray])
        field.layer.borderWidth = Helper.getWidthOf(xdWidth: 1.0, referenceWidth: nil, originalWidth: nil)
        field.borderColor = UIColor(hex: "#95989A")!
        field.borderColorOnSelected = UIColor(hex: "#CE9340")!
        field.textColor = UIColor(hex: "#95989A")
        field.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 20, referenceHeight: nil, referenceWidth: nil))
        
        var topBottomPadding = Helper.getWidthOf(xdWidth: 13, referenceWidth: nil, originalWidth: nil)
        var leftRightPadding = Helper.getWidthOf(xdWidth: 21, referenceWidth: nil, originalWidth: nil)
        
        field.padding = UIEdgeInsets(top: topBottomPadding, left: leftRightPadding, bottom: topBottomPadding, right: leftRightPadding)
        
        return field
    }()
    
    let summonerNameField: TextField = {
        let field = TextField()
        field.backgroundColor = UIColor(hex: "#0D161F")
        field.attributedPlaceholder = NSAttributedString(string: "Summoner Name", attributes: [NSAttributedStringKey.foregroundColor: UIColor(hex: "#95989A") ?? UIColor.lightGray])
        field.layer.borderWidth = Helper.getWidthOf(xdWidth: 1.0, referenceWidth: nil, originalWidth: nil)
        field.borderColor = UIColor(hex: "#95989A")!
        field.borderColorOnSelected = UIColor(hex: "#CE9340")!
        field.textColor = UIColor(hex: "#95989A")
        field.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 20, referenceHeight: nil, referenceWidth: nil))
        
        var topBottomPadding = Helper.getWidthOf(xdWidth: 13, referenceWidth: nil, originalWidth: nil)
        var leftRightPadding = Helper.getWidthOf(xdWidth: 21, referenceWidth: nil, originalWidth: nil)
        
        field.padding = UIEdgeInsets(top: topBottomPadding, left: leftRightPadding, bottom: topBottomPadding, right: leftRightPadding)
        
        return field
    }()
    
    let passwordField: TextField = {
        let field = TextField()
        field.backgroundColor = UIColor(hex: "#0D161F")
        field.attributedPlaceholder = NSAttributedString(string: "Password", attributes: [NSAttributedStringKey.foregroundColor: UIColor(hex: "#95989A") ?? UIColor.lightGray])
        field.isSecureTextEntry = true
        field.layer.borderWidth = Helper.getWidthOf(xdWidth: 1.0, referenceWidth: nil, originalWidth: nil)
        field.borderColor = UIColor(hex: "#95989A")!
        field.borderColorOnSelected = UIColor(hex: "#CE9340")!
        field.textColor = UIColor(hex: "#95989A")
        field.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 20, referenceHeight: nil, referenceWidth: nil))
        
        var topBottomPadding = Helper.getWidthOf(xdWidth: 13, referenceWidth: nil, originalWidth: nil)
        var leftRightPadding = Helper.getWidthOf(xdWidth: 21, referenceWidth: nil, originalWidth: nil)
        
        field.padding = UIEdgeInsets(top: topBottomPadding, left: leftRightPadding, bottom: topBottomPadding, right: leftRightPadding)
        
        return field
    }()
    
    let signupButton: UIButton = {
        let button = UIButton()
        button.setBackgroundColor(color: UIColor(hex: "#010A13")!, forState: .normal)
        button.setBackgroundColor(color: UIColor(hex: "#CE9340")!, forState: .highlighted)
        button.setTitleColor(UIColor(hex: "#CE9340"), for: .normal)
        button.setTitleColor(UIColor(hex: "#010A13"), for: .highlighted)
        button.setTitle("SIGN UP", for: .normal)
        button.layer.borderWidth = Helper.getWidthOf(xdWidth: 1.0, referenceWidth: nil, originalWidth: nil)
        button.layer.borderColor = UIColor(hex: "#CE9340")?.cgColor
        button.titleLabel?.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 32, referenceHeight: nil, referenceWidth: nil))
        
        button.addTarget(self, action: #selector(signupPressed(sender:)), for: .touchUpInside)
        return button
    }()
    
    let alreadyHaveAccountLabel: UILabel = {
        let label = UILabel()
        label.text = "Already have an account?"
        label.textColor = UIColor(hex: "#95989A")
        label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 20, referenceHeight: nil, referenceWidth: nil))
        return label
    }()
    
    ////////// END OF CONTROLS /////////
    
    override init(frame: CGRect) {
        super.init(frame: frame)
        setupGestures()
        setupView()
        setupConstraints()
    }
    
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    
    func setupView() {
        
    }
    
    func setupGestures() {
        // Enable user interaction
        alreadyHaveAccountLabel.isUserInteractionEnabled = true
        
        // Set gestures
        self.alreadyHaveAccountTapped = UITapGestureRecognizer(target: self, action: #selector(alreadyHaveAccountPressed))
        
        // Add gestures
        alreadyHaveAccountLabel.addGestureRecognizer(alreadyHaveAccountTapped)
    }
    
    func setupConstraints() {
        // MARK: private variables
        let defaultHeight:CGFloat = Helper.getHeightOf(xdHeight: 43, referenceHeight: nil, originalHeight: nil)
        
        // MARK: Add subviews
        addSubview(self.logo)
        addSubview(emailField)
        addSubview(summonerNameField)
        addSubview(passwordField)
        addSubview(signupButton)
        addSubview(alreadyHaveAccountLabel)
        
        // MARK: Disable frames
        logo.translatesAutoresizingMaskIntoConstraints = false
        emailField.translatesAutoresizingMaskIntoConstraints = false
        summonerNameField.translatesAutoresizingMaskIntoConstraints = false
        passwordField.translatesAutoresizingMaskIntoConstraints = false
        signupButton.translatesAutoresizingMaskIntoConstraints = false
        alreadyHaveAccountLabel.translatesAutoresizingMaskIntoConstraints = false
        
        // MARK: Constraints
        // LOGO
        logo.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        logo.topAnchor.constraint(equalTo: topAnchor, constant: Helper.getHeightOf(xdHeight: 15, referenceHeight: nil, originalHeight: nil)).isActive = true
        logo.widthAnchor.constraint(equalToConstant: Helper.getWidthOf(xdWidth: 208, referenceWidth: nil, originalWidth: nil)).isActive = true
        logo.heightAnchor.constraint(equalToConstant: Helper.getHeightOf(xdHeight: 84, referenceHeight: nil, originalHeight: nil)).isActive = true
        
        // EMAIL FIELD
        emailField.topAnchor.constraint(equalTo: logo.bottomAnchor, constant: Helper.getHeightOf(xdHeight: 58, referenceHeight: nil, originalHeight: nil)).isActive = true
        emailField.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        emailField.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
        emailField.heightAnchor.constraint(equalToConstant: defaultHeight).isActive = true
        
        // SUMMONER NAME FIELD
        summonerNameField.topAnchor.constraint(equalTo: emailField.bottomAnchor, constant: Helper.getHeightOf(xdHeight: 26, referenceHeight: nil, originalHeight: nil)).isActive = true
        summonerNameField.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        summonerNameField.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
        summonerNameField.heightAnchor.constraint(equalToConstant: defaultHeight).isActive = true
        
        // PASSWORD FIELD
        passwordField.topAnchor.constraint(equalTo: summonerNameField.bottomAnchor, constant: Helper.getHeightOf(xdHeight: 26, referenceHeight: nil, originalHeight: nil)).isActive = true
        passwordField.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        passwordField.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
        passwordField.heightAnchor.constraint(equalToConstant: defaultHeight).isActive = true
        
        // LOGIN BUTTON
        signupButton.topAnchor.constraint(equalTo: passwordField.bottomAnchor, constant: Helper.getHeightOf(xdHeight: 58, referenceHeight: nil, originalHeight: nil)).isActive = true
        signupButton.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        signupButton.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
        signupButton.heightAnchor.constraint(equalToConstant: defaultHeight).isActive = true
        
        // ALREADY HAVE AN ACCOUNT LABEL
        alreadyHaveAccountLabel.topAnchor.constraint(equalTo: signupButton.bottomAnchor, constant: Helper.getHeightOf(xdHeight: 18, referenceHeight: nil, originalHeight: nil)).isActive = true
        alreadyHaveAccountLabel.leftAnchor.constraint(equalTo: leftAnchor).isActive = true
    }
    
    @IBAction func signupPressed(sender: AnyObject) {
        self.delegate?.didPressSignup(form: self)
    }
    
    @objc func alreadyHaveAccountPressed() {
        self.delegate?.didPressAlreadyHaveAccount(form: self)
    }
}
